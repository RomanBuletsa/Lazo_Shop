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
    }
}
