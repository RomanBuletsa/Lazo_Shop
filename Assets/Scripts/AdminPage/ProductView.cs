using System;
using System.Linq;
using Application;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdminPage
{
    public class ProductView : MonoBehaviour
    {
        [SerializeField] private TMP_Text idText;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private Button showProductModelButton;
        public event Action<GameObject> ProductModelButtonClicked;
        private GameObject productModel;

        public void Show(ProductData product)
        {
            idText.text = product.identification;
            nameText.text = product.name;
            amountText.text = product.amount.ToString();
            priceText.text = product.price.ToString();
            productModel = ApplicationManager.Instance.DataHolder.Models.FirstOrDefault(s => s.name.ToString() == product.modelName)?.model;
            if (productModel != null)
                showProductModelButton.onClick.AddListener(() => ProductModelButtonClicked?.Invoke(productModel));
        }
    }
}
