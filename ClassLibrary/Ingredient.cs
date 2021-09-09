namespace Classes
{
    public enum IngredientType
    {
        Normal,
        Powder
    }

    public enum StrengthUnit
    {
        MG,
        G,
        ML,
        TAB,
        CAP
    }

    public class Ingredient : Entity
    {
        public int DIN { get; set; }
        public string Strength { get; set; }
        public double Quantity { get; set; }
        public int UPC { get; set; }
        public int DrugCode { get; set; }
        public IngredientType IngredientType { get; set; }
        public StrengthUnit StrengthUnit { get; set; }
    }
}