using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoops_KatelynNicholson_2025_11_03
{
    internal class Program
    {
        //green islands shark cant touch 
        //score tracker
        //keep track of if game is playing
        static bool isPlaying = true;

        // keep track of users input
        static int verticalInput = 0;
        static int horizontalInput = 0;

        //gameState
        static int verticalPos = 0;
        static int horizontalPos = 0;
        static int tickMs = 17;

        //shark
        static int sharkVertical = 5;
        static int sharkHorizontal = 5;
        static int sharkTickMs = 0;
        static int sharkDelay = 10;

        //Currency
        static int pickUP = 0;

        //Objects
        static string player = "Ö";
        static string shark = "^";
        static string pickUps = "¿■?";

        //Map
        static string[,] map = { 
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "▓░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░▓", "▓▓░░", "░▓▓░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "▓▓▓▓", "▓▓▓▓", "▓▓▓▓", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░▓▓", "▓▓▓▓", "▓▓▓▓", "▓▓▓▓", "▓░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░▓", "▓▓▓▓", "▓▓▓▓", "▓▓▓▓", "▓▓░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░▓", "▓▓░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"}
        };

        static void Main()
        {
            //game loop
            while (isPlaying)
            {
                //input
                ProcessInput();
                //move player

                //update
                Update();
                //move shark

                //check collisions, part of the unity flow
                //UpdateCollision(); ?

                //draw
                Draw();
                Draw(map); //foreach

                //repeat
                
                Thread.Sleep(tickMs); //gives the game a constant tick rate

            }
        }

        static void ProcessInput()
        {

            horizontalInput = 0;
            verticalInput = 0;

            //guard clause
            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.W) horizontalInput -= 1;
            if (inputKey.Key == ConsoleKey.A) horizontalInput += 1;
            if (inputKey.Key == ConsoleKey.S) horizontalInput -= 1;
            if (inputKey.Key == ConsoleKey.D) horizontalInput += 1;
            if (inputKey.Key == ConsoleKey.Q) isPlaying = false;

        }
        static void Update()
        {
            verticalPos += verticalInput;
            horizontalPos += horizontalInput;

            verticalPos = Mathf.Clamp(verticalPos, 0, map.GetLength(0) - 1);
            horizontalPos = Mathf.Clamp(horizontalPos, 0, map.GetLength(1) - 1);

            sharkTickMs++;
            if (sharkTickMs < sharkDelay) return;

            sharkTickMs = 0;

            if (sharkVertical < verticalPos) sharkVertial++;
            else if (sharkHorizontal > horizontalPos) sharkHorizontal--;

            if ((sharkHorizontal < horizontalPos) sharkHorizontal++;
            if (sharkHorizontal < horizontalPos) sharkHorizontal--;

            if (sharkVertical == verticalPos && sharlHorizontal == horizontalPos)
            {
                isPlaying = false;
                Console.Clear();
                Console.WriteLine("The shark got you! Game Over");
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
            }

        }

        static void Draw()
        {

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Horizontal Position: " + horizontalPos + "      ");
            Console.WriteLine("Vertical Position: " + verticalPos + "      ");
            
        }
        static void Draw(string[,] map)
        {
            //draw map forloop
            Console.SetCursorPosition(0, 3);
            for (int y = 0; y < map.GetLength(0); y++)
            {

                for (int x = 0; x < map.GetLength(1); x++)
                {
                    char tile = map[y,x];
                    switch (tile)
                    {
                        case '░': //water
                            Console.ForgroundColor = ConsoleColor.Blue; break;
                        case '▓'; //islands
                            Console.ForgroundColor = ConsoleColor.Green; break;
                        case '¿■?'; //pickups
                            Console.ForgorundColor = ConsoleColor.Yellow; break;
                        case 'Ö'; //player
                            Console.ForgroundColor = ConsoleColor.White; break;
                        case ' '; //shark
                            Console.ForgroundColor = ConsoleColor.White; break;
                    }

                    Console.Write(tile);
                    Console.ResetColor();

                    if (y == verticalPos && x == horizontalPos)
                        Console.Write(player);

                    else if (y == sharkVertical && x == sharkHorizontal)
                        Console.Write(shark);
                    
                    else
                        Console.Write(map[y, x]);

                }

                Console.WriteLine();
            }
        }
    }
}
