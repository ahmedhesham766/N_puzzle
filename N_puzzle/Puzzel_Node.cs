using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle
{
    internal class Puzzel_Node
    {
        //id to check if puzzle in any list (open or closed)
        public String puzzle_key = "";
        public int Size;
        public int[,] state;
        //num of moves
        public int g;
        //pos of blank space
        public int blank_Row;
        public int blank_Col;

        public int Hamming_Value;
        public int Manhattan_Value;
        //type of movements
        public String type;
        //f = g + hurstic(hamming or manhatten)
        public int f;
        public Puzzel_Node parent;       
        public Puzzel_Node(int size, int[,] puzzel_board, int blank_row, int blank_col) //o(s^2)
        {
            this.Size = size;
            this.state = new int[Size, Size];
            for (int i = 0 ; i < Size ; i++)
            {
                for (int j = 0 ; j < Size ; j++)
                {
                    state[i, j] = puzzel_board[i, j];
                    puzzle_key = puzzel_board[i, j].ToString();
                }
            }
            this.type = "initial_state";
            this.Hamming();
            this.Manhhatan();
            this.blank_Row = blank_row;
            this.blank_Col = blank_col;
            this.g= 0;
            this.parent = null; 
        }
        public Puzzel_Node(Puzzel_Node child)
        {
            this.Size = child.Size;
            this.state = new int[Size, Size];
            for (int i = 0 ; i < Size ; i++)
            {
                for (int j = 0 ; j < Size ; j++)
                {
                    state[i, j] = child.state[i, j];
                }
            }
            this.g = child.g + 1;
            this.blank_Row = child.blank_Row;
            this.blank_Col = child.blank_Col;
            this.parent = child.parent;
        }
        public Puzzel_Node(Puzzel_Node puzzle, int _default) 
        {
            this.Size = puzzle.Size;
            this.state = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    state[i, j] = puzzle.state[i, j];
                }
            }
            this.blank_Row = puzzle.blank_Row;
            this.blank_Col = puzzle.blank_Col;
            this.g = puzzle.g;
            this.Hamming_Value = puzzle.Hamming_Value;
            this.Manhattan_Value = puzzle.Manhattan_Value;
            this.f = puzzle.f;
            this.parent = puzzle;
            this.puzzle_key = puzzle.puzzle_key;
        }
        public void f_Hamming() //o(1)
        {
            f = g + Hamming_Value;
        }
        public void f_Manhattan()
        {
            f = g + Manhattan_Value;
        }
        public Puzzel_Node Move_right() //o(1)
        {
            state[blank_Row, blank_Col] = state[blank_Row, blank_Col + 1];
            state[blank_Row, blank_Col + 1] = 0;
            blank_Col = blank_Col + 1;
            return this;
        }
        public Puzzel_Node Move_Left() 
        {
            state[blank_Row, blank_Col] = state[blank_Row, blank_Col - 1];
            state[blank_Row, blank_Col - 1] = 0;
            blank_Col = blank_Col - 1;
            return this;
        }
        public Puzzel_Node Move_Up()
        {
            state[blank_Row, blank_Col] = state[blank_Row - 1, blank_Col ];
            state[blank_Row - 1, blank_Col] = 0;
            blank_Row = blank_Row - 1;
            return this;
        }
        public Puzzel_Node Move_Down()
        {
            state[blank_Row, blank_Col] = state[blank_Row + 1, blank_Col];
            state[blank_Row + 1, blank_Col] = 0;
            blank_Row = blank_Row + 1;
            return this;
        }
        public void Hamming() //order(s^2)
        {
            int h = 0;
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    puzzle_key += state[i, j].ToString();
                    if (i == Size - 1 && j == Size - 1)
                    {
                        count = 0;
                    }
                    else
                    {
                        count++;
                    }
                    if (state[i, j] != count)
                    {
                        h++;
                    }
                }
            }
            Hamming_Value = h;
        }
        public void Manhhatan() //order(s^2)
        {
            int manhhatan_value = 0;
            int expected = 0;
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    puzzle_key += state[row, col].ToString();
                    int value = state[row, col];
                    expected++;

                    if (value != 0 && value != expected)
                    {
                        manhhatan_value += Math.Abs(row - ((value - 1) / this.Size)) + Math.Abs(col - ((value - 1) % Size)); 
                    }
                }
            }
            Manhattan_Value = manhhatan_value;
        }
        public Boolean Goal_Hamming() //o(1)
        {
            if (Hamming_Value == 0)
            {
                return true ; 
            }
            else 
            { 
                return false ; 
            }
        }
        public Boolean Goal_Manhhatan() //o(1)
        {
            if (Manhattan_Value == 0)
            {
                return true ; 
            }
            else
            {
                return false ; 
            }
        }
        public void display() //o(s^2)
        {
            Console.WriteLine("Action: " + type);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(state[i, j] + " ");
                }
                 Console.WriteLine(); 
            }
            Console.WriteLine();
        }
    }
}
