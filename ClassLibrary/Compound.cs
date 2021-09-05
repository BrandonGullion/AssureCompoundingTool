using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Compound : Entity
    {
        public List<Ingredient> Ingredients { get; set; }
        public double TotalQuantity { get; set; }
        public int Repeats { get; set; }
    }
}
