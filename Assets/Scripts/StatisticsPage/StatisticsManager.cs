using System.Collections.Generic;
using System.Linq;
using Application;
using Data;
using UnityEngine;

namespace StatisticsPage
{
    public class StatisticsManager : MonoBehaviour
    {
    
        [SerializeField] private StatisticsProductView statisticsProductViewPrefab; 
        [SerializeField] private Transform sceneParent;
        private Dictionary<ProductData, StatisticsProductView> statisticsProductViews;
        void Start()
        {
            ShowAllProducts();
        }

        private void ShowAllProducts()
        {
            var salesData = ApplicationManager.Instance.DataHolder.GetSalesData();
            var productsData = ApplicationManager.Instance.DataHolder.GetProductsData();
            var productData = productsData.Select(data => new ProductData(data.identification, data.name,
                salesData.Where(s => s.productIdentification == data.identification).Select(d => d.amount).Sum(),
                data.price * salesData.Where(s => s.productIdentification == data.identification).Select(d => d.amount)
                    .Sum(),
                data.costs * salesData.Where(s => s.productIdentification == data.identification).Select(d => d.amount)
                    .Sum())).ToList();
            
            statisticsProductViews?.Values.ToList().ForEach(v =>
            {
                Destroy(v.gameObject);
            });
            
            statisticsProductViews = new Dictionary<ProductData, StatisticsProductView>();
            
            productData.ForEach((u) =>
            {
                var statisticsProductView = Instantiate(statisticsProductViewPrefab, sceneParent);
                statisticsProductView.Show(u);
                statisticsProductViews.Add(u, statisticsProductView);
            });
        }
    }
}
