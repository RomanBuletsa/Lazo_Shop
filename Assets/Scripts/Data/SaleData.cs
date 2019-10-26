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

        public SaleData(string userNickname, string productIdentification, int amount, int price, DateTime date)
        {
            this.userNickname = userNickname;
            this.productIdentification = productIdentification;
            this.amount = amount;
            this.price = price;
            this.date = date;
        }
    }
}
