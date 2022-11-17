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
        public void removeEdge(Vertex node1, Vertex node2) {
            // Update node1 values to not include node2
            List<Vertex> adjacentNodes = adjacent[node1];
            adjacent.Remove(node1);
            adjacentNodes.Remove(node2);
            adjacent.Add(node1, adjacentNodes);
        }
        public override string ToString() {
            string output = "";
            foreach (KeyValuePair<Vertex, List<Vertex>> kvp in adjacent) {
                output += kvp.Key.getLabel() + " --> ";
                foreach(Vertex node in kvp.Value){
                    output += node.getLabel() + ",";
                }
                output += " \n";
            }

            return output;
        }
        public List<string> randomTraversal(Vertex root) {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<string> visited = new List<string>();
            Vertex currentNode = root;
            string currentNodeValue = root.getLabel();
            int totalOpen = 0;
            int totalClose = 0;

            while (!currentNode.getLabel().Equals("Done")) {
                Vertex previousNode = currentNode;
                

                // Traverse to new node
                while (true) {
                    int randomIndex = random.Next(adjacent[previousNode].Count);
                    currentNode = adjacent[previousNode][randomIndex];
                    currentNodeValue = currentNode.getLabel();
                    if (currentNode.getLabel().Equals(")")) // If the next node is a close parenthesis
                    {
                        if (totalOpen > totalClose) // make sure it is syntactically correct to add a close parenthesis
                        {
                            totalClose++;
                            break;
                        }
                        else {
                            continue;
                        }
                    }
                    break;
                }
                visited.Add(currentNodeValue);
                // Keep track of open parenthesis
                switch (currentNodeValue) {
                    case "(":
                    case "Functions":
                        totalOpen++;
                        break;
                }
                
            }

            return visited;
        }
    }
}
