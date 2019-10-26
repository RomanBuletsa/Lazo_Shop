using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DataHolder", menuName = "Configs/DataHolder")]
    public class DataHolder : ScriptableObject
    {
        [SerializeField] private List<UserData> usersData;
        [SerializeField] private List<ProductData> productsData;
        [SerializeField] private List<SaleData> salesData;
        [SerializeField] private List<PurchaseData> purchasesData;
    
        public List<UserData> GetUsersData() => usersData;
        public List<ProductData> GetProductsData() => productsData;
        public List<SaleData> GetSalesData() => salesData;
        public List<PurchaseData> GetPurchasesData() => purchasesData;
    }
}
