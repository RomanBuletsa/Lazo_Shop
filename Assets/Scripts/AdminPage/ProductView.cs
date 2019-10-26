using System;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdminPage
{
    public class ProductView : MonoBehaviour
    {
        public event Action<ProductData> ProductSelected;
		
        [SerializeField] private TMP_Text idText;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private Button button;

        public void Show(ProductData product)
        {
            idText.text = product.identification;
            nameText.text = product.name;
            amountText.text = product.amount.ToString();
            priceText.text = product.price.ToString();

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => ProductSelected?.Invoke(product));
        }
    }
}
