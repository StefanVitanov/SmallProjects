using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FallingRocks
{   

    class FallingRocks
    {
        struct Objects
        {
            public int x;
            public int y;
            public string c;
        }
        static void RemuveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
        static void PrintOnPosition(int x, int y, string c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
        static void PrintDwarfOnPosition(int x, int y, string c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
       

        static void Main(string[] args)
        {
            int score = new int();
            Random randomGenerator = new Random();
            Objects dwarf = new Objects();
            dwarf.x = Console.WindowWidth / 2;
            dwarf.y = Console.WindowHeight - 1;
            dwarf.c = "(0)";
            RemuveScrollBars();
            List<Objects> rocks = new List<Objects>();
           
            while (true)
            {                

                PrintDwarfOnPosition(dwarf.x,dwarf.y,dwarf.c);
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.x - 1 >= 0)
                        {
                            dwarf.x = dwarf.x - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.x + 1 < Console.WindowWidth-2)
                        {
                            dwarf.x = dwarf.x + 1;
                        }
                    }

                }
                Random randRock = new Random();
                string rockSymbol = "";
                switch (randRock.Next(0, 12))
                {
                    case 0:
                        rockSymbol = "^^^";
                        break;
                    case 1:
                        rockSymbol = "@@";
                        break;
                    case 2:
                        rockSymbol = "****";
                        break;
                    case 3:
                        rockSymbol = "&";
                        break;
                    case 4:
                        rockSymbol = "++";
                        break;
                    case 5:
                        rockSymbol = "%";
                        break;
                    case 6:
                        rockSymbol = "$";
                        break;
                    case 7:
                        rockSymbol = "#";
                        break;
                    case 8:
                        rockSymbol = "!";
                        break;
                    case 9:
                        rockSymbol = ".";
                        break;
                    case 10:
                        rockSymbol = ";";
                        break;
                    case 11:
                        rockSymbol = "-";
                        break;
                    default:
                        Environment.Exit(1);
                        break;
                }                
                Objects rock = new Objects();
                rock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
                rock.y = 0;
                rock.c = rockSymbol;
                rocks.Add(rock);
                List<Objects> newRocks = new List<Objects>();
                for (int i = 0; i < rocks.Count; i++)
                {
                    Objects oldRock = rocks[i];
                    Objects newRock = new Objects();
                    newRock.x = oldRock.x;
                    newRock.y = oldRock.y + 1;
                    newRock.c = oldRock.c;
                    
                    if(newRock.y <= Console.WindowHeight-1)
                    {
                        newRocks.Add(newRock);
                    }
                    if (newRock.y == Console.WindowHeight - 1)
                    {     
                            score++;                
                    }
                    if ((newRock.x == dwarf.x+1) && (newRock.y == dwarf.y))
                    {

                        PrintOnPosition(Console.WindowWidth / 2, Console.WindowHeight / 2, "Game Over");
                        PrintOnPosition(Console.WindowWidth / 2, 0, "Scores:" + Convert.ToString(score));
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                }
                rocks = newRocks;
                foreach (Objects part in rocks)
                {
                    PrintOnPosition(part.x, part.y, part.c);
                }

                Thread.Sleep(150);
                Console.Clear();
            }
        }
    }
}
