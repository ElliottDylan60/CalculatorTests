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
        Graph graph;
        Vertex Arithmetic = new Vertex("Arithmetic");
        Vertex Digit = new Vertex("Digit");
        Vertex UnaryMinus = new Vertex("Unary Minus");
        Vertex Functions = new Vertex("Functions");
        Vertex OpenParenthesis = new Vertex("(");
        Vertex CloseParenthesis = new Vertex(")");
        Vertex Empty = new Vertex("Empty");
        Vertex Decimal = new Vertex("Decimal");
        Vertex Done = new Vertex("Done");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGraph();
            Console.WriteLine(graph);
        }
        private void InitializeGraph() {
            // Create Graph
            graph = new Graph();
            #region AddingNodes
            

            graph.addVertex(Arithmetic);
            graph.addVertex(Digit);
            graph.addVertex(UnaryMinus);
            graph.addVertex(Functions);
            graph.addVertex(OpenParenthesis);
            graph.addVertex(CloseParenthesis);
            graph.addVertex(Empty);
            graph.addVertex(Decimal);
            graph.addVertex(Done);
            #endregion
            #region AddingEdges
            graph.addEdge(Arithmetic, Digit);
            graph.addEdge(Arithmetic, Functions);
            graph.addEdge(Arithmetic, OpenParenthesis);
            graph.addEdge(Arithmetic, UnaryMinus);
            graph.addEdge(Arithmetic, Decimal);

            graph.addEdge(Digit, Arithmetic);
            graph.addEdge(Digit, Digit);
            graph.addEdge(Digit, Decimal);
            graph.addEdge(Digit, Done);

            graph.addEdge(UnaryMinus, UnaryMinus);
            graph.addEdge(UnaryMinus, Digit);
            graph.addEdge(UnaryMinus, OpenParenthesis);
            graph.addEdge(UnaryMinus, Decimal);

            graph.addEdge(Functions, CloseParenthesis);
            graph.addEdge(Functions, Digit);
            graph.addEdge(Functions, Decimal);
            graph.addEdge(Functions, UnaryMinus);
            graph.addEdge(Functions, Functions);
            graph.addEdge(Functions, OpenParenthesis);

            graph.addEdge(OpenParenthesis, Digit);
            graph.addEdge(OpenParenthesis, CloseParenthesis);
            graph.addEdge(OpenParenthesis, Functions);
            graph.addEdge(OpenParenthesis, UnaryMinus);
            graph.addEdge(OpenParenthesis, Decimal);
            graph.addEdge(OpenParenthesis, OpenParenthesis);

            graph.addEdge(CloseParenthesis, Digit);
            graph.addEdge(CloseParenthesis, Arithmetic);
            graph.addEdge(CloseParenthesis, Done);

            graph.addEdge(Empty, Digit);
            graph.addEdge(Empty, Decimal);
            graph.addEdge(Empty, Functions);
            graph.addEdge(Empty, OpenParenthesis);
            graph.addEdge(Empty, UnaryMinus);
            graph.addEdge(Empty, Done);

            graph.addEdge(Decimal, Digit);
            #endregion
            
        }
    }
}
