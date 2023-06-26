using DungeonsOfDoom.Core;
using System.Text;

namespace DungeonsOfDoom
{
    class Program
    {
        Room[,] rooms;
        Player player;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Play();
        }

        public void Play()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            player = new Player();
            CreateRooms();

            do
            {
                Console.Clear();
                DisplayRooms();
                DisplayStats();
                if (AskForMovement())
                {
                    ExploreRoom();
                }
            } while (player.IsAlive && Monster.MonsterCounter > 0);

            GameOver();
        }


        void CreateRooms()
        {
            rooms = new Room[20, 5];
            for (int y = 0; y < rooms.GetLength(1); y++)
            {
                for (int x = 0; x < rooms.GetLength(0); x++)
                {
                    rooms[x, y] = new Room();

                    int spawnChance = RandomUtils.SpawnChance(0, 101);
                    if (spawnChance < 10 && spawnChance >= 5)
                        rooms[x, y].MonsterInRoom = new Skeleton();
                    else if (spawnChance < 5)
                    {
                        rooms[x, y].MonsterInRoom = new Mummy();
                    }
                    else if (spawnChance < 20)
                        rooms[x, y].ItemInRoom = new TeleportPotion();
                    if (spawnChance < 10 && RandomUtils.IsEven(spawnChance))
                        rooms[x, y].ItemInRoom = new GlovesOfMetal();

                }
            }
        }

        void DisplayRooms()
        {
            for (int y = 0; y < rooms.GetLength(1); y++)
            {
                for (int x = 0; x < rooms.GetLength(0); x++)
                {
                    Room room = rooms[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write(player.Health >= player.MaxHealth / 2 ? "🙂" : "😲");
                    else if (room.MonsterInRoom != null)
                        Console.Write("😈");
                    else if (room.ItemInRoom != null)
                        Console.Write("📦");
                    else
                        Console.Write("🔹");
                }
                Console.WriteLine();
            }
        }

        void DisplayStats()
        {
            Console.WriteLine($"❤️{player.Health}/{player.MaxHealth}\t👹{Monster.MonsterCounter}");

            if (player.Inventory.Count != 0)
            {
                Console.WriteLine("Inventory:");
                int numOfGloves = 0;
                int numOfSkeletons = 0;
                int numOfMummies = 0;
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    if (player.Inventory[i] is GlovesOfMetal)
                        numOfGloves++;
                    else if (player.Inventory[i] is Skeleton)
                        numOfSkeletons++;
                    else
                        numOfMummies++;
                }
                if (numOfGloves > 0)
                    Console.WriteLine($"{numOfGloves} {(numOfGloves > 1 ? "Gloves of metal" : "Gloves of metal")}");
                if (numOfSkeletons > 0)
                    Console.WriteLine($"{numOfSkeletons} {(numOfSkeletons > 1 ? "Skeleton cadavers" : "Skeleton cadaver")}");
                if (numOfMummies > 0)
                    Console.WriteLine($"{numOfMummies} {(numOfMummies > 1 ? "Mummy cadavers" : "Mummy cadaver")}");
            }

        }

        bool AskForMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }

            if (isValidKey &&
                newX >= 0 && newX < rooms.GetLength(0) &&
                newY >= 0 && newY < rooms.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;
                return true;
            }
            else return false;
        }

        void ExploreRoom()
        {
            Room room = rooms[player.X, player.Y];
            if ((room.MonsterInRoom != null && room.ItemInRoom != null) || room.MonsterInRoom != null)
            {

                player.Attack(room.MonsterInRoom);

                if (room.MonsterInRoom.IsAlive)
                    room.MonsterInRoom.Attack(player);
                else
                {
                    if (room.ItemInRoom != null)
                    {
                        player.Inventory.Add(room.ItemInRoom);
                    }
                    player.Inventory.Add(room.MonsterInRoom);
                    room.MonsterInRoom = null;
                    Monster.MonsterCounter--;
                }
            }
            else if (room.ItemInRoom != null)
            {
                player.TeleportAndHeal(rooms.GetLength(0), rooms.GetLength(1));
                room.ItemInRoom = null;
            }

        }

        void GameOver()
        {
            Console.Clear();
            if (!player.IsAlive)
            {

                Console.WriteLine("Game over...");
            }
            else
                Console.WriteLine("You won!");

            Console.ReadKey();
            Play();
        }
    }
}
