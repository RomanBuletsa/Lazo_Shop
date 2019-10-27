using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Application;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        if (product == null || product.amount < Convert.ToInt32(amountInputField.text)) return;
        var saleData = new SaleData(nicknameInputField.text, idInputField.text,
            Convert.ToInt32(amountInputField.text), product.price, DateTime.Now);
        ApplicationManager.Instance.DataHolder.GetSalesData().Add(saleData);

        product.amount -= Convert.ToInt32(amountInputField.text);
        product.profit += Convert.ToInt32(amountInputField.text) * product.price;
        
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
