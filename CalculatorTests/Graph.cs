using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class Graph
    {
        private Dictionary<Vertex, List<Vertex>> adjacent = new Dictionary<Vertex, List<Vertex>>();
        public void addVertex(Vertex node) {
            adjacent.Add(node, new List<Vertex>());
        }
        public void removeVertex(Vertex node) {
            adjacent.Remove(node);
        }
        public void addEdge(Vertex node1, Vertex node2) { 

            // Update node1 values to include node2
            List<Vertex> adjacentNodes = adjacent[node1];
            adjacent.Remove(node1);
            adjacentNodes.Add(node2);
            adjacent.Add(node1, adjacentNodes);
        }

        public override string ToString() {
            string output = "";
            foreach (KeyValuePair<Vertex, List<Vertex>> kvp in adjacent) {
                output += kvp.Key.getLabel() + " --> ";
                foreach(Vertex node in kvp.Value){
                    output += node.getLabel() + " ";
                }
                output += " \n";
            }

            return output;
        }
    }
}
