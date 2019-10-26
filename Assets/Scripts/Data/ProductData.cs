using System;

namespace Data
{
    [Serializable]
    public sealed class ProductData
    {
        public string identification;
        public string name;
        public int amount;
        public int price;
        public int costs;
        public int profit;

        public ProductData(string identification, string name, int amount, int price, int costs)
        {
            this.identification = identification;
            this.name = name;
            this.amount = amount;
            this.price = price;
            this.costs = costs;
        }
    }
}
