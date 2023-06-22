﻿using DungeonsOfDoom.Core;
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
            } while (player.IsAlive);

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

                    int spawnChance = Random.Shared.Next(1, 100 + 1);
                    if (spawnChance < 10 && spawnChance >= 5)
                        rooms[x, y].MonsterInRoom = new Skeleton();
                    else if (spawnChance < 5)
                    {
                        rooms[x, y].MonsterInRoom = new Mummy();
                    }
                    else if (spawnChance < 20)
                        rooms[x, y].ItemInRoom = new Sword();
                    if (spawnChance < 10 && spawnChance % 2 == 0)
                        rooms[x, y].ItemInRoom = new Spoon();

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
                        Console.Write(player.Health >= Player.MaxHealth / 2 ? "🙂" : "😲");
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
            Console.WriteLine($"❤️{player.Health}/{Player.MaxHealth}");

            if (player.Inventory.Count != 0)
            {
                Console.WriteLine("Inventory:");
                int numOfSpoons = 0;
                int numOfSwords = 0;
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    if (player.Inventory[i].Name == "Spoon")
                        numOfSpoons++;
                    else
                        numOfSwords++;
                }
                if(numOfSwords > 0) 
                    Console.WriteLine($"{numOfSwords} {(numOfSwords > 1 ? "Swords" : "Sword")}");
                if (numOfSpoons > 0) 
                    Console.WriteLine($"{numOfSpoons} {(numOfSpoons > 1 ? "Spoons" : "Spoon")}");
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
                    room.MonsterInRoom = null;
                }
            }
            else if (room.ItemInRoom != null)
            {
                player.Inventory.Add(room.ItemInRoom);
                room.ItemInRoom = null; 
            }
            
        }

        void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
        }
    }
}
