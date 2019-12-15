﻿using System;
using System.Linq;
using Application;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdminPage
{
    public class SellProductView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField idInputField;
        [SerializeField] private TMP_InputField amountInputField;
        [SerializeField] private TMP_InputField nicknameInputField;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;

        private void Start()
        {
            okButton.onClick.AddListener(SellProducts);
            cancelButton.onClick.AddListener(Hide);
        }

        private void SellProducts()
        {
            var products = ApplicationManager.Instance.DataHolder.GetProductsData().Where((s) => s.identification == idInputField.text);
            var product = products.FirstOrDefault();
            var oldProductData = product;
            if (product == null || product.amount < Convert.ToInt32(amountInputField.text)) return;
            var saleData = new SaleData(nicknameInputField.text, idInputField.text,
                Convert.ToInt32(amountInputField.text), product.price, DateTime.Now);
            ApplicationManager.Instance.DataHolder.GetSalesData().Add(saleData);

            product.amount -= Convert.ToInt32(amountInputField.text);
            product.profit += Convert.ToInt32(amountInputField.text) * product.price;
        
            ApplicationManager.Instance.AdminPageManager.UpdateData(oldProductData, product);

            var user = ApplicationManager.Instance.DataHolder
                .GetUsersData().FirstOrDefault(s => s.nickname == nicknameInputField.text);

            if (user != null) user.spent += Convert.ToInt32(amountInputField.text) * product.price;

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
