/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace N_puzzle
{
    class Program
    {
        static int BlankROW, BlankCOL;
        static void Main(string[] args)
        { 
            Console.WriteLine("[1] Solve using Hamming\n[2] Solve using Manhhatan\n");

            Console.Write("Please enter your choice : ");

            char Choice = (char)Console.ReadLine()[0]; 
            
            int[,] Puzzle_Board = ReadFile("8 Puzzle (1).txt");

            if (Choice == '1')
            {
                if (ISSolvabe(Puzzle_Board))
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("This puzzle is solvable");
                  
                    Puzzel_Node puzzle = new Puzzel_Node(Puzzle_Board.GetLength(0), Puzzle_Board, BlankROW, BlankCOL);
                    Hmming_Astar A2 = new Hmming_Astar();
                    // solving the puzzle using hamming
                    A2.Astar_Hamming(puzzle);
                }
                else
                {

                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("This puzzle is unsolvable");
                    
                }

            }
            else if (Choice == '2')
            {
                if (ISSolvabe(Puzzle_Board))
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("This puzzle is solvable");
                    
                    Puzzel_Node puzzle = new Puzzel_Node(Puzzle_Board.GetLength(0), Puzzle_Board, BlankROW, BlankCOL);
                    Manhhatan_Astar A = new Manhhatan_Astar();
                    // solving the puzzle using manhhatan
                    A.Astar_Manhatten(puzzle);
                }
                else
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("This puzzle is unsolvable");
                   
                }
            }


        }


        static int[,] ReadFile(string FileName)
        {
            FileStream file_S = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            StreamReader S_Reader = new StreamReader(file_S);
            // geting the size from the file
            String Line = S_Reader.ReadLine();
            int Board_Size = int.Parse(Line);
            int[,] Puzzle_Board = new int[Board_Size, Board_Size];

            if (S_Reader.Read() == '\r' || S_Reader.Read() == '\n')
            {
                S_Reader.ReadLine();
            }
            string Board = S_Reader.ReadToEnd();
            //Console.WriteLine(Board);
            int rowind = 0;
            int colind;
            // filling 2D array  
            foreach(var row in Board.Split('\n'))
            {
                colind = 0;
                if(row.Equals(""))
                {
                    continue;
                }
                foreach (var col in row.Trim().Split(' '))
                {
                    Puzzle_Board[rowind, colind] = int.Parse(col.Trim());
                    if(int.Parse(col.Trim()) == 0)
                    {
                        BlankROW = rowind;
                        BlankCOL = colind;
                    }
                    colind++;
                }
                rowind++;
            }
            return Puzzle_Board;
        }
        static int getInvCount(int[,] puzzle)  // order (S^2)
        {
            int[] Puzzle_1D = puzzle.Cast<int>().ToArray();
            int Inv_Count = 0;
            int ArrLen = puzzle.GetLength(0) * puzzle.GetLength(0);
            for(int i = 0; i < ArrLen - 1; i++)
            {              
                for(int j = i + 1; j < ArrLen; j++)
                {
                    if((Puzzle_1D[i] != 0 && Puzzle_1D[j] != 0) && Puzzle_1D[i] > Puzzle_1D[j])
                    {
                        Inv_Count++;
                    }
                }
            }
            return Inv_Count;
        }
        static int BlankSpace_Pos(int[,] puzzle)  // Order (S)
        {
            for(int i = puzzle.GetLength(0) - 1; i >= 0;i--)
            {
                for (int j = puzzle.GetLength(1) - 1; j >= 0; j--)
                {
                    if(puzzle[i,j] == 0)
                    {
                        return puzzle.GetLength(0) - i;
                    }
                }
            }
            return 0;
        }
        static bool ISSolvabe(int[,] puzzle) // Order (1)
        {
            int count = getInvCount(puzzle);
            int Blank_Pos = BlankSpace_Pos(puzzle);

            if (puzzle.GetLength(0) % 2 != 0)
            {
                if ((count  % 2 == 0))
                {
                    return true;
                }
            }
            else
            {
                if ((count % 2 != 0) && (Blank_Pos % 2 == 0) || (count % 2 == 0) && (Blank_Pos % 2 != 0))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace N_puzzle
{
    class Program
    {
        static int BlankROW, BlankCOL;
        static void Main(string[] args)
        {
            Console.WriteLine("[1] Solve using Hamming\n[2] Solve using Manhhatan\n");

            Console.Write("Please enter your choice : ");

            char Choice = (char)Console.ReadLine()[0];

            int[,] Puzzle_Board = ReadFile("8 Puzzle (1).txt");

            if (Choice == '1')
            {
                if (ISSolvabe(Puzzle_Board))
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("This puzzle is solvable");

                    Puzzel_Node puzzle = new Puzzel_Node(Puzzle_Board.GetLength(0), Puzzle_Board, BlankROW, BlankCOL);
                    Hmming_Astar A2 = new Hmming_Astar();
                    // solving the puzzle using hamming
                    A2.Astar_Hamming(puzzle);
                }
                else
                {

                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("This puzzle is unsolvable");

                }

            }
            else if (Choice == '2')
            {
                if (ISSolvabe(Puzzle_Board))
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("This puzzle is solvable");

                    Puzzel_Node puzzle = new Puzzel_Node(Puzzle_Board.GetLength(0), Puzzle_Board, BlankROW, BlankCOL);
                    Manhhatan_Astar A = new Manhhatan_Astar();
                    // solving the puzzle using manhhatan
                    A.Astar_Manhatten(puzzle);
                }
                else
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("This puzzle is unsolvable");

                }
            }


        }


        static int[,] ReadFile(string FileName)
        {
            FileStream file_S = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            StreamReader S_Reader = new StreamReader(file_S);
            // geting the size from the file
            String Line = S_Reader.ReadLine();
            int Board_Size = int.Parse(Line);
            int[,] Puzzle_Board = new int[Board_Size, Board_Size];

            if (S_Reader.Read() == '\r' || S_Reader.Read() == '\n')
            {
                S_Reader.ReadLine();
            }
            string Board = S_Reader.ReadToEnd();
            //Console.WriteLine(Board);
            int rowind = 0;
            int colind;
            // filling 2D array  
            foreach (var row in Board.Split('\n'))
            {
                colind = 0;
                if (row.Equals(""))
                {
                    continue;
                }
                foreach (var col in row.Trim().Split(' '))
                {
                    Puzzle_Board[rowind, colind] = int.Parse(col.Trim());
                    if (int.Parse(col.Trim()) == 0)
                    {
                        BlankROW = rowind;
                        BlankCOL = colind;
                    }
                    colind++;
                }
                rowind++;
            }
            return Puzzle_Board;
        }
        static int getInvCount(int[,] puzzle)  // order (S^2)
        {
            int[] Puzzle_1D = puzzle.Cast<int>().ToArray();
            int Inv_Count = 0;
            int ArrLen = puzzle.GetLength(0) * puzzle.GetLength(0);
            for (int i = 0; i < ArrLen - 1; i++)
            {
                for (int j = i + 1; j < ArrLen; j++)
                {
                    if ((Puzzle_1D[i] != 0 && Puzzle_1D[j] != 0) && Puzzle_1D[i] > Puzzle_1D[j])
                    {
                        Inv_Count++;
                    }
                }
            }
            return Inv_Count;
        }
        static int BlankSpace_Pos(int[,] puzzle)  // Order (S)
        {
            for (int i = puzzle.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = puzzle.GetLength(1) - 1; j >= 0; j--)
                {
                    if (puzzle[i, j] == 0)
                    {
                        return puzzle.GetLength(0) - i;
                    }
                }
            }
            return 0;
        }
        static bool ISSolvabe(int[,] puzzle) // Order (1)
        {
            int count = getInvCount(puzzle);
            int Blank_Pos = BlankSpace_Pos(puzzle);

            if (puzzle.GetLength(0) % 2 != 0)
            {
                if ((count % 2 == 0))
                {
                    return true;
                }
            }
            else
            {
                if ((count % 2 != 0) && (Blank_Pos % 2 == 0) || (count % 2 == 0) && (Blank_Pos % 2 != 0))
                {
                    return true;
                }
            }
            return false;
        }
    }
}









