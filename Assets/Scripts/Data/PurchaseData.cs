using System;

namespace Data
{
    [Serializable]
    public sealed class PurchaseData
    {
        public string productIdentification;
        public int amount;
        public int price;
        public DateTime date;
    }
}
