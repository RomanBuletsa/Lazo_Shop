using System;
using System.Collections.Generic;
using Application;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdminPage
{
    public class AdminPageManager : MonoBehaviour
    {
        [SerializeField] private Transform productsParent;
        [SerializeField] private ProductView productViewPrefab;
        [SerializeField] private AddProductView addProductView;
        [SerializeField] private TMP_InputField searchText;
        [SerializeField] private Button searchButton;
        [SerializeField] private Button addProductsButton;
        [SerializeField] private Button sellProductsButton;

        private Dictionary<ProductData, ProductView> productViews;
        
        private void Awake() => ApplicationManager.Instance.AdminPageManager = this;
        private void OnDestroy() => ApplicationManager.Instance.AdminPageManager = null;

        private void Start()
        {
            productViews = new Dictionary<ProductData, ProductView>();
            searchButton.onClick.AddListener(Search);
            addProductsButton.onClick.AddListener(addProductView.Show);
            ViewProducts();
        }
        
        private void ViewProducts()
        {
            ApplicationManager.Instance.DataHolder.GetProductsData().ForEach(product =>
                {
                    var view = Instantiate(productViewPrefab, productsParent);
                    productViews.Add(product, view);
                    view.ProductSelected += OnProductSelect;
                    view.Show(product);
                    view.gameObject.SetActive(true);
                }
                );
        }

        private void OnProductSelect(ProductData products)
        {
            
        }

        private void Search()
        {
            foreach (var productView in productViews)
            {
                productView.Value.gameObject.SetActive(productView.Key.name.Contains(searchText.text));
            }
        }

    }
}
