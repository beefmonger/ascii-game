using System;
using System.Threading;
namespace ascii_game
{

    class Pixel
    {
        public int x;
        public int y;
        public char whatToShowThere;
        //garfield you are a figment of my imagination garfield
    }

    class Program
    {
        static void Main(string[] args)
        {
            //declare variables
            int currentMapWidth = 20;
            int currentMapHeight = 10;
            int playerX = 0;
            int playerY = 0;
            int cameraX;
            int cameraY;
            bool gameRunning = false;
            char avatarSprite = 'v';
            char floorSprite = '_';
            bool appRunning = false;
            string entireDisplayString = "the display should go here";

            //run app
            appRunning = true;

            while (appRunning)
            {

                //prompt and store displayWidth and displayHeight (disabled)
                /*
                Console.Write("Enter map width:\n");
                Int32.TryParse(Console.ReadLine(), out currentMapWidth);
                Console.Write("Enter map height:\n");
                Int32.TryParse(Console.ReadLine(), out currentMapHeight);
                */


                //run game
                gameRunning = true;

                //main game running sequence 
                while (gameRunning)
                {
                    
                    entireDisplayString = "";
                    for (int renderYStep = 0; renderYStep <= (currentMapHeight - 1); renderYStep++)
                    {
                        for (int renderXStep = 0; renderXStep <= (currentMapWidth - 1); renderXStep++)
                        {
                            //if in player position, add player, else add floor
                            if (renderXStep == playerX && renderYStep == playerY) { entireDisplayString = entireDisplayString + avatarSprite; }
                            else { entireDisplayString = entireDisplayString + floorSprite; }
                        }

                        //ends that line of pixels
                        entireDisplayString = entireDisplayString + "\n";
                    }

                    Console.Clear();
                    Console.Write(entireDisplayString);

                    //gather and interpret player input
                    ConsoleKeyInfo ckiMainTurnInput = Console.ReadKey(true);

                        //interpret player input
                        switch (ckiMainTurnInput.KeyChar)
                        {

                            case 's':
                                playerY++;
                                break;
                            case 'a':
                                playerX--;
                                break;
                            case 'w':
                                playerY--;
                                break;
                            case 'd':
                                playerX++;
                                break;
                            case 'q':
                                gameRunning = false;
                                break;
                            default:                                
                                break;
                        }
                }

                Console.Write("Game ended. Press R to restart, press Q again to finish.");

                ConsoleKeyInfo ckiEndInput = Console.ReadKey(true);
                
                switch (ckiEndInput.KeyChar)
                {
                    case 'r':
                        gameRunning = true;
                        break;
                    case 'q':
                        appRunning = false;
                        break;
                }
            }
        }
    }
}
