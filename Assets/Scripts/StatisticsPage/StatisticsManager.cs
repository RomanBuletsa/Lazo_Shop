using System.Collections.Generic;
using System.Linq;
using Application;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StatisticsPage
{
    public class StatisticsManager : MonoBehaviour
    {
    
        [SerializeField] private StatisticsProductView statisticsProductViewPrefab; 
        [SerializeField] private Transform sceneParent;
        [SerializeField] private Button backButton;
        private Dictionary<ProductData, StatisticsProductView> statisticsProductViews;
        void Start()
        {
            backButton.onClick.AddListener(UnloadScene);
            ShowAllProducts();
        }
        
        private void UnloadScene()
        {
            SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());
            SceneManager.UnloadScene(ApplicationScenes.StatisticsPage.ToString());
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
                    .Sum(), ModelName.None.ToString())).ToList();
            
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
