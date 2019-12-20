using System;
using System.Collections.Generic;
using Application;
using Data;
using SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AdminPage
{
    public class AdminPageManager : MonoBehaviour
    {
        [SerializeField] private Transform productsParent;
        [SerializeField] private ProductView productViewPrefab;
        [SerializeField] private AddProductView addProductView;
        [SerializeField] private SellProductView sellProductView;
        [SerializeField] private TMP_InputField searchText;
        [SerializeField] private Button searchButton;
        [SerializeField] private Button addProductsButton;
        [SerializeField] private Button sellProductsButton;
        [SerializeField] private Button backButton;

        private Dictionary<ProductData, ProductView> productViews;

        public GameObject ProductModel { get; private set; }

        private void Awake() => ApplicationManager.Instance.AdminPageManager = this;
        private void OnDestroy() => ApplicationManager.Instance.AdminPageManager = null;

        private void Start()
        {
            productViews = new Dictionary<ProductData, ProductView>();
            searchButton.onClick.AddListener(Search);
            backButton.onClick.AddListener(()=> SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString()));
            addProductsButton.onClick.AddListener(addProductView.Show);
            sellProductsButton.onClick.AddListener(sellProductView.Show);
            ViewProducts();
        }
        
        private void ViewProducts()
        {
            ApplicationManager.Instance.DataHolder.GetProductsData().ForEach(AddProduct);
        }

        public void AddProduct(ProductData product)
        {
            var view = Instantiate(productViewPrefab, productsParent);
            productViews.Add(product, view);
            view.Show(product);
            view.gameObject.SetActive(true);
            view.ProductModelButtonClicked += ShowProductModel;
        }

        private void ShowProductModel(GameObject productModel)
        {
            ProductModel = productModel;
            ScenesLoader.LoadScene(ApplicationScenes.Exhibition.ToString(), true, false);
        }

        public void UpdateData(ProductData oldProductData, ProductData newProductData)
        {
            var productView = productViews[oldProductData];
            productView.Show(newProductData);
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
