using System;
using System.Collections.Generic;

namespace CursorStructBewegungen
{
    class MainClass
    {

        struct TPosition
        {
            public int XPos;
            public int YPos;

            public TPosition(int x, int y)
            {
                XPos = x;
                YPos = y;
                CheckPosition();
            }

            public void CheckPosition()
            {
                if (XPos > 79 || XPos < 0 || YPos > 24 || YPos < 0)
                {
                    Console.WriteLine("Punkt außerhalb des Bereichs.");
                    Console.ReadLine();
                }
            }

            public void WriteCursor(char sign)
            {
                Console.SetCursorPosition(XPos, YPos);
                Console.Write(sign);
            }
        }

        struct TUfo
        {
            public TPosition Position;
            public Char Sign;
            public int XPos;
            public int YPos;
            Random Rnd;
            public List<int> list;
            public bool tarnKappe;

            public TUfo(int x, int y, char sign)
            {
                Sign = sign;
                XPos = x;
                YPos = y;
                Rnd = new Random(4561);
                Position = new TPosition(XPos, YPos);
                list = new List<int>();
                tarnKappe = false;
            }

            public void MoveSign()
            {
                while (true) {
                    int xRnd = Rnd.Next(-1, 2);
                    int yRnd = Rnd.Next(-1, 2);
                    Position.XPos = Position.XPos + xRnd;
                    Position.YPos = Position.YPos + yRnd;
                    Position.CheckPosition();
                    if(Console.KeyAvailable)
                    {
                        ConsoleKeyInfo cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.T)
                        {
                            if (tarnKappe == false)
                            {
                                tarnKappe = true;
                            }
                            else
                            {
                                tarnKappe = false;
                            }
                        }
                    }
                    Console.Clear();
                    if (!tarnKappe)
                    {
                        Position.WriteCursor('*');
                    }
                    Console.SetCursorPosition(0, 0);
                    System.Threading.Thread.Sleep(200);

                }



            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("X-Koordinate angeben");
            string Xstr = Console.ReadLine();
            Console.WriteLine("Y-Koordinate eingeben");
            string yStr = Console.ReadLine();
            Console.Clear();

            int xPos = Int32.Parse(Xstr);
            int yPos = Int32.Parse(yStr);
            TUfo tUfo = new TUfo(xPos, yPos, '*');
            tUfo.Position.WriteCursor('*');
            tUfo.MoveSign();


        }

    }
}
