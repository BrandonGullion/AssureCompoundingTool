using System.Collections.Generic;

namespace ClassLibrary
{
    public class PDIN
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MedicalIngredient> EligibleIngredient { get; set; }
    }
}