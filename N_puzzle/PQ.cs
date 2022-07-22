using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle
{
    internal class PQ
    {
        public List<Puzzel_Node> Puzzles;
        public PQ()
        {
            this.Puzzles = new List<Puzzel_Node>();
        }
        public void Enqueue(Puzzel_Node puzzle) //o(log(v))
        {
            Puzzles.Add(puzzle); //o(1)
            // make the tree keep the heap property  
            minheapify();  //o(log(v))
        }
        public void minheapify() //O(log v)
        {
            int childern_index = Puzzles.Count - 1; 
            // to check if node has childerns or not 
            while (childern_index > 0)
            {
                int parent_index = (childern_index - 1) / 2;
                // childern.f must be larger or equal than parent.f
                if (Puzzles[childern_index].f.CompareTo(Puzzles[parent_index].f) >= 0)
                {
                    break;
                }
                else
                {
                    Puzzel_Node swap = Puzzles[childern_index];
                    Puzzles[childern_index] = Puzzles[parent_index];
                    Puzzles[parent_index] = swap;
                    childern_index = parent_index;
                }              
            }
        }
        public Puzzel_Node Dequeue() //o(log(v))
        {
            // before remove
            int last_index = Puzzles.Count - 1; 

            Puzzel_Node highest_priority_node = Puzzles[0];  

            Puzzles[0] = Puzzles[last_index];  
            
            Puzzles.RemoveAt(last_index);

            heap_extract_min(); 

            return highest_priority_node;
        }
        public void heap_extract_min() //o(log(V))
        {
            //after remove
            int last_index = Puzzles.Count - 1;
            int smallest = 0;  
            int parent_index = 0; 
            while (true)
            {
                int left_childern_index = parent_index * 2 + 1;
                //parent doesnt have childerns
                if (left_childern_index > last_index)
                {
                    break ;
                }
                int right_childern_index = left_childern_index + 1;   
                // if there is a right child , and it is smaller than left child, use the rc instead
                if (left_childern_index <= last_index && Puzzles[left_childern_index].f.CompareTo(Puzzles[parent_index].f) < 0)
                {
                    smallest = left_childern_index;
                }
                else
                {
                    smallest = parent_index;
                }    
                if(right_childern_index <= last_index && Puzzles[right_childern_index].f.CompareTo(Puzzles[smallest].f) < 0)
                {
                    smallest = right_childern_index;
                }
                if(smallest != parent_index)
                {
                    Puzzel_Node swap = Puzzles[parent_index];
                    Puzzles[parent_index] = Puzzles[smallest];
                    Puzzles[smallest] = swap;
                    parent_index = smallest;
                }
                else
                {
                    break;
                }
            }
        }
        public Boolean is_empty() //o(1)
        {
            if ( Puzzles.Count == 0 ) 
            { 
                return true ; 
            }
            else
            { 
                return false ; 
            }
        }      
    }
}
