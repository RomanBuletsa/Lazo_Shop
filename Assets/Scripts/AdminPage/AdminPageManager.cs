using System;
using System.Collections.Generic;
using Application;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdminPage
{
    public class AdminPageManager : MonoBehaviour
    {
        [SerializeField] private Transform productsParent;
        [SerializeField] private ProductView productViewPrefab;
        [SerializeField] private TMP_InputField searchText;
        [SerializeField] private Button searchButton;

        private List<ProductView> productViews;
        
        private void Awake() => ApplicationManager.Instance.AdminPageManager = this;
        private void OnDestroy() => ApplicationManager.Instance.AdminPageManager = null;

        private void Start()
        {
            productViews = new List<ProductView>();
            searchButton.onClick.AddListener(Search);
            ViewProducts("");
        }
        private void ViewProducts(string substring)
        {
            foreach (var view in productViews)
            {
                Destroy(view.gameObject);
            }
            productViews.Clear();
            
            ApplicationManager.Instance.DataHolder.GetProductsData().ForEach(product =>
                {
                    if (!product.name.Contains(substring)) return;
                    var view = Instantiate(productViewPrefab, productsParent);
                    productViews.Add(view);
                    view.Show(product);
                    view.gameObject.SetActive(true);
                }
                );
        }
        
        private void Search()
        {
            ViewProducts(searchText.text);
        }

    }
}
