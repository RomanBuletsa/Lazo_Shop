﻿using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdminPage
{
    public class AddProductView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField idInputField;
        [SerializeField] private TMP_InputField amountInputField;
        [SerializeField] private TMP_InputField costInputField;
        [SerializeField] private TMP_InputField priceInputField;
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private Dropdown dropdown;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;

        private List<string> modelNames;
            
        private void Start()
        {
            modelNames = new List<string>(Enum.GetNames(typeof(ModelName)));
            okButton.onClick.AddListener(AddProducts);
            cancelButton.onClick.AddListener(Hide);
            dropdown.AddOptions(modelNames);
        }

        private void AddProducts()
        {
            var products = ApplicationManager.Instance.DataHolder.GetProductsData().Where((s) => s.identification == idInputField.text);
            var product = products.FirstOrDefault();
            var oldProductData = product;
            if (product != null)
            {
                product.amount += Convert.ToInt32(amountInputField.text);
                if(priceInputField.text.Length > 0)
                    product.price = Convert.ToInt32(priceInputField.text);
                if(costInputField.text.Length > 0)
                    product.costs += Convert.ToInt32(costInputField.text) * Convert.ToInt32(amountInputField.text);
                product.modelName = modelNames[dropdown.value];
                
                ApplicationManager.Instance.AdminPageManager.UpdateData(oldProductData, product);
            }
            else
            {
                var productData = new ProductData(idInputField.text, nameInputField.text,
                    Convert.ToInt32(amountInputField.text), Convert.ToInt32(priceInputField.text),
                    Convert.ToInt32(costInputField.text) * Convert.ToInt32(amountInputField.text), modelNames[dropdown.value]);
                ApplicationManager.Instance.DataHolder.GetProductsData().Add(productData);
                
                ApplicationManager.Instance.AdminPageManager.AddProduct(productData);
            }
            
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
