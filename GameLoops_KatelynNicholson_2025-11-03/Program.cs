using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoops_KatelynNicholson_2025_11_03
{
    internal class Program
    {
        //green islands shark cant touch 
        //map is blue
        //slow the shark so its not moving 1 tile per frame
        //premake map it will make it easier
        //Water ░ BLUE
        //Island ▓ GREEN
        //Pickups ¿■? = $$$ //Orange or YELLOW
        //score tracker
        //Player Ö
        //Shark ^
        //keep track of if game is playing
        static bool isPlaying = true;

        // keep track of users input
        static int verticalInput = 0;
        static int horizontalInput = 0;

        //gameState
        static int verticalPos = 0;
        static int horizontalPos = 0;
        static int tickMs = 17;

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
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
        { "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░", "░░░░"},
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
            if (inputKey.Key == ConsoleKey.S) horizontalInput += 1;
            if (inputKey.Key == ConsoleKey.D) horizontalInput -= 1;
            if (inputKey.Key == ConsoleKey.Q) isPlaying = false;

        }
        static void Update()
        {

            verticalPos += verticalInput;
            horizontalPos += horizontalInput;

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
            
        }
    }
}
