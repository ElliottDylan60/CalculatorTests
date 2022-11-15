using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class Vertex
    {
        private string label;
        public Vertex(string label) {
            this.label = label;
        }
        public string getLabel() {
            return label;
        }
    }
}
