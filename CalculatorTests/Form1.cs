using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorTests
{
    public partial class Form1 : Form
    {
        // Global Variables
        Graph graph = new Graph();
        Vertex Add = new Vertex("+");
        Vertex Subtract = new Vertex("-");
        Vertex Multiply = new Vertex("*");
        Vertex Divide = new Vertex("/");
        Vertex Int = new Vertex("Int");
        Vertex Double = new Vertex("Double");
        Vertex UnaryMinus = new Vertex("Unary Minus");
        Vertex Functions = new Vertex("Functions");
        Vertex OpenParenthesis = new Vertex("(");
        Vertex CloseParenthesis = new Vertex(")");
        Vertex Empty = new Vertex("Empty");
        Vertex Done = new Vertex("Done");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGraph();
            
            evaluateRandom(graph.randomTraversal(Empty));
        }
        private void InitializeGraph() {
            // Create Graph
            #region AddingNodes
            graph.addVertex(Int);
            graph.addVertex(Double);
            graph.addVertex(Add);
            graph.addVertex(Subtract);
            graph.addVertex(Multiply);
            graph.addVertex(Divide);
            graph.addVertex(UnaryMinus);
            graph.addVertex(Functions);
            graph.addVertex(OpenParenthesis);
            graph.addVertex(CloseParenthesis);
            graph.addVertex(Empty);
            graph.addVertex(Done);
            #endregion

            #region AddingEdges
            /*
                Add
            */
            graph.addEdge(Add, Double);
            graph.addEdge(Add, Int);
            graph.addEdge(Add, Functions);
            graph.addEdge(Add, OpenParenthesis);
            graph.addEdge(Add, UnaryMinus);
            /*
                Subtract
            */
            graph.addEdge(Subtract, Double);
            graph.addEdge(Subtract, Int);
            graph.addEdge(Subtract, Functions);
            graph.addEdge(Subtract, OpenParenthesis);
            graph.addEdge(Subtract, UnaryMinus);
            /*
                Multiply
            */
            graph.addEdge(Multiply, Double);
            graph.addEdge(Multiply, Int);
            graph.addEdge(Multiply, Functions);
            graph.addEdge(Multiply, OpenParenthesis);
            graph.addEdge(Multiply, UnaryMinus);
            /*
                Divide
            */
            graph.addEdge(Divide, Double);
            graph.addEdge(Divide, Int);
            graph.addEdge(Divide, Functions);
            graph.addEdge(Divide, OpenParenthesis);
            graph.addEdge(Divide, UnaryMinus);
            /*
                Int
            */
            graph.addEdge(Int, Add);
            graph.addEdge(Int, Subtract);
            graph.addEdge(Int, Multiply);
            graph.addEdge(Int, Divide);
            graph.addEdge(Int, Done);
            graph.addEdge(Int, CloseParenthesis);
            /*
                Double
            */
            graph.addEdge(Double, Add);
            graph.addEdge(Double, Subtract);
            graph.addEdge(Double, Multiply);
            graph.addEdge(Double, Divide);
            graph.addEdge(Double, Done);
            graph.addEdge(Double, CloseParenthesis);
            /*
                -
            */
            graph.addEdge(UnaryMinus, UnaryMinus);
            graph.addEdge(UnaryMinus, Double);
            graph.addEdge(UnaryMinus, Int);
            graph.addEdge(UnaryMinus, OpenParenthesis);
            /*
                Functions
            */
            graph.addEdge(Functions, Double);
            graph.addEdge(Functions, Int);
            graph.addEdge(Functions, UnaryMinus);
            graph.addEdge(Functions, Functions);
            graph.addEdge(Functions, OpenParenthesis);
            /*
                (
            */
            graph.addEdge(OpenParenthesis, Double);
            graph.addEdge(OpenParenthesis, Int);
            graph.addEdge(OpenParenthesis, Functions);
            graph.addEdge(OpenParenthesis, UnaryMinus);
            graph.addEdge(OpenParenthesis, OpenParenthesis);
            /*
                )
            */
            graph.addEdge(CloseParenthesis, Double);
            graph.addEdge(CloseParenthesis, Int); ;
            graph.addEdge(CloseParenthesis, Add);
            graph.addEdge(CloseParenthesis, Subtract);
            graph.addEdge(CloseParenthesis, Multiply);
            graph.addEdge(CloseParenthesis, Divide);
            graph.addEdge(CloseParenthesis, Done);
            /*
                Empty
            */
            graph.addEdge(Empty, Double);
            graph.addEdge(Empty, Int);
            graph.addEdge(Empty, Functions);
            graph.addEdge(Empty, OpenParenthesis);
            graph.addEdge(Empty, UnaryMinus);
            //graph.addEdge(Empty, Done);

            #endregion
            
        }
        private void evaluateRandom(List<string> equation) {
            int numOpen = 0;
            int numClose = 0;
            string result = "";

            foreach (string token in equation) {
                Random random = new Random(Guid.NewGuid().GetHashCode());

                switch (token) {
                    case "Int":
                        result += random.Next(9999);
                        break;
                    case "Double":
                        double value = random.NextDouble() * 9999;
                        value = System.Math.Round(value, random.Next(6));
                        result += value;
                        break;
                    case "Functions":
                        List<string> func = new List<string> { "sin(", "cos(", "tan(", "csc(", "log(", "ln("};
                        result += func[random.Next(func.Count)];
                        break;
                    case "Unary Minus":
                        result += "-";
                        break;
                    case "Done":
                        break;
                    default:
                        result += token;
                        break;
                }
            }

            foreach (char ch in result) {
                if (ch == '(')
                {
                    numOpen++;
                }
                else if (ch == ')') {
                    numClose++;
                }
            }
            while (true) {
                if (numOpen > numClose)
                {
                    result += ")";
                    numClose++;
                }
                break;
            }
            Console.WriteLine(result);

        }
    }
}
