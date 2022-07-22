using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle
{
    internal class Hmming_Astar
    {
        public List<Puzzel_Node> Solution_Path = new List<Puzzel_Node>();
        public List<Puzzel_Node> closed_list = new List<Puzzel_Node>();
        public PQ open_list = new PQ();
        public Dictionary<string, Puzzel_Node> Unique_open_list = new Dictionary<string, Puzzel_Node>();
        public Dictionary<string, Puzzel_Node> Uninue_closed_list = new Dictionary<string, Puzzel_Node>();
        public System.Diagnostics.Stopwatch c = new System.Diagnostics.Stopwatch();

        public void Astar_Hamming(Puzzel_Node puzzel)
        {
            Unique_open_list.Add(puzzel.puzzle_key, puzzel);
            open_list.Enqueue(puzzel);
            c.Start();
            while (!open_list.is_empty())
            {
                Puzzel_Node q = open_list.Dequeue();
                Puzzel_Node H_puzzle = new Puzzel_Node(q, 0);
                if (!Child_in_Closed(H_puzzle))
                {
                    Uninue_closed_list.Add(H_puzzle.puzzle_key, H_puzzle);
                    closed_list.Add(H_puzzle);
                    if (H_puzzle.blank_Col - 1 >= 0)
                    {
                        //left
                        Puzzel_Node Child = new Puzzel_Node(H_puzzle);
                        Child.Move_Left(); Child.Hamming(); Child.f_Hamming();
                        if (Child.Goal_Hamming())
                        {
                            Child.type = "Goal";
                            Solution_Path.Add(Child);
                            Display_Path(Child);
                        }
                        Child.type = "Left";
                        //check if child in open list or not
                        if (!Child_in_Open(Child))
                        {
                            open_list.Enqueue(Child); Unique_open_list.Add(Child.puzzle_key, Child);
                        }
                    }
                    if (H_puzzle.blank_Col + 1 <= puzzel.Size - 1)
                    {
                        // right
                        Puzzel_Node Child = new Puzzel_Node(H_puzzle);
                        Child.Move_right(); Child.Hamming(); Child.f_Hamming();
                        if (Child.Goal_Hamming())
                        {
                            Child.type = "Goal";
                            Solution_Path.Add(Child);
                            Display_Path(Child);
                        }
                        Child.type = "Right";
                        //check if child in open list or not
                        if (!Child_in_Open(Child))
                        {
                            open_list.Enqueue(Child); Unique_open_list.Add(Child.puzzle_key, Child);
                        }
                    }
                    if (H_puzzle.blank_Row - 1 >= 0)
                    {
                        //up
                        Puzzel_Node Child = new Puzzel_Node(H_puzzle);
                        Child.Move_Up();Child.Hamming();Child.f_Hamming();
                        if (Child.Goal_Hamming())
                        {
                            Child.type = "Goal";
                            Solution_Path.Add(Child);
                            Display_Path(Child);
                        }
                        Child.type = "Up";
                        //check if child in open list or not
                        if (!Child_in_Open(Child))
                        {
                            open_list.Enqueue(Child); Unique_open_list.Add(Child.puzzle_key, Child);
                        }
                    }
                    if (H_puzzle.blank_Row + 1 <= puzzel.Size - 1)
                    {
                        //down
                        Puzzel_Node Child = new Puzzel_Node(H_puzzle);
                        Child.Move_Down(); Child.Hamming(); Child.f_Hamming();
                        if (Child.Goal_Hamming())
                        {
                            Child.type = "Goal";
                            Solution_Path.Add(Child);
                            Display_Path(Child);
                        }
                        Child.type = "Down";
                        //check if child in open list or not
                        if (!Child_in_Open(Child))
                        {
                            open_list.Enqueue(Child); Unique_open_list.Add(Child.puzzle_key, Child);
                        }
                    }
                }
            }
        }
        public bool Child_in_Closed(Puzzel_Node node)
        {
            bool x = false;
            if (Uninue_closed_list.ContainsKey(node.puzzle_key))
            {
                Puzzel_Node n = Uninue_closed_list[node.puzzle_key];
                if (n.f < node.f)
                {
                    open_list.Enqueue(n);
                    Unique_open_list.Add(n.puzzle_key, n);
                }
                x = true;
            }
            return x;
        }
        public bool Child_in_Open(Puzzel_Node c)
        {
            bool check = Unique_open_list.ContainsKey(c.puzzle_key);
            return check;
        }
        public void Display_Path(Puzzel_Node Goal)
        {
            Puzzel_Node childs_parent = Goal.parent;
            while (childs_parent.parent != null)
            {
                Solution_Path.Add(childs_parent);
                childs_parent = childs_parent.parent;
            }
            // Add Start Board
            Solution_Path.Add(childs_parent);
            Print_Path();
        }
        public void Print_Path()
        {            
            int Min = Solution_Path.Count() - 1;
            for (int i = Min; i >= 0 ; i--)
            {
                Solution_Path[i].display();
            }
            Console.WriteLine("--------------------------------");         
            Console.Write(" Total number of Movements = " + Min);
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            c.Stop();
            Console.WriteLine($"Execution Time: {c.Elapsed}");
            Environment.Exit(0);
        }
    }
}
