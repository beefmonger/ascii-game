using System;
using System.Collections.Generic;
using System.Threading;
namespace ascii_game
{    
    class pixel
    {
        //private data members
        public int x { get; set; }
        public int y { get; set; }
        public char pixelChar { get; set; }


        //garfield i love you
    }
    class goblin {

        public float health { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool seesPlayer { get; set; }
        public float fiendishness { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //declare variables
            int displayWidth = 9;
            int displayHeight = 7;
            int currentMapWidth = 20;
            int currentMapHeight = 10;
            int playerX = 0;
            int playerY = 0;
            int cameraX = playerX;
            int cameraY = playerY;
            bool gameRunning = false;
            char avatarSprite = 'v';
            char floorSprite = '_';
            bool appRunning = false;
            string entireDisplayString = "the display should go here";
            char goblinSprite = 'g';
            int currentMap;

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
                List<pixel> pixelList = new List<pixel>();
                //run game
                gameRunning = true;
                while (gameRunning)
                {
                    //assign pixelList
                    pixelList.Clear();
                    for (int assignYStep = 0; assignYStep <= (currentMapHeight - 1); assignYStep++)
                    {
                        for (int assignXStep = 0; assignXStep <= (currentMapWidth - 1); assignXStep++)
                        {                               
                            //assign char to current pixel being assigned
                            if (assignXStep == playerX && assignYStep == playerY) 
                            {
                                pixelList.Add(new pixel() { x = assignXStep, y = assignYStep, pixelChar = avatarSprite });
                            }
                            else 
                            { 
                                pixelList.Add(new pixel() { x = assignXStep, y = assignYStep, pixelChar = floorSprite }); 
                            }
                        }
                    }
                    pixelList.TrimExcess();

                    //render: this is where you're gonna use camera coords and visibility.
                    entireDisplayString = "";
                    for (int renderYStep = 0; renderYStep <= (displayHeight - 1); renderYStep++)
                    {
                        for (int renderXStep = 0; renderXStep <= (displayWidth - 1); renderXStep++)
                        {
                            // Find pixel by its coords
                            pixel result = pixelList.Find
                            (
                            delegate (pixel pixel)
                            {
                                return (pixel.x == renderXStep + cameraX - 0.5 * (displayWidth - 1) && pixel.y == renderYStep + cameraY - 0.5 * (displayHeight - 1));
                            }
                            );

                            if (result != null) 
                            { 
                                entireDisplayString = entireDisplayString + result.pixelChar; 
                            } 
                            else 
                            { 
                                entireDisplayString = entireDisplayString + ' '; 
                            }
                        }
                        entireDisplayString = entireDisplayString + "\n";
                    } 
                    Console.Clear();
                    Console.Write(entireDisplayString);

                    //gather and interpret player input
                    ConsoleKeyInfo ckiMainTurnInput = Console.ReadKey(true);
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
                    cameraX = playerX;
                    cameraY = playerY;
                    Thread.Sleep(10);
                }

                //end gameRunning loop, end menu prompts
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
