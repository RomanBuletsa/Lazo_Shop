using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace StatisticsPage
{
    public class StatisticsProductView : MonoBehaviour
    {
        [SerializeField] private TMP_Text name;
        [SerializeField] private TMP_Text amount;
        [SerializeField] private TMP_Text profit;

        public void Show(ProductData productData)
        {
            name.text = productData.name;
            amount.text = productData.amount.ToString();
            profit.text = productData.Profit.ToString();
        }
    }
}
