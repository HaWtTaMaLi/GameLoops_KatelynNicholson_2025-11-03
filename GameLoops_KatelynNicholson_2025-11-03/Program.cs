using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoops_KatelynNicholson_2025_11_03
{
    internal class Program
    {

        //keep track of if game is playing
        static bool isPlaying = true;

        // keep track of users input
        static int verticalInput = 0;
        static int horizontalInput = 0;

        //gameState
        static int verticalPos = 0;
        static int horizontalPos = 0;
        static int tickMs = 17;

        static void Main()
        {

            //game loop
            while (isPlaying)
            {

                ProcessInput();
                Update();
                Draw();
                

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
    }
}
