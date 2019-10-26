using System;

namespace Data
{
    [Serializable]
    public sealed class SaleData
    {
        public string userNickname;
        public string productIdentification;
        public int amount;
        public int price;
        public DateTime date;
    }
}
