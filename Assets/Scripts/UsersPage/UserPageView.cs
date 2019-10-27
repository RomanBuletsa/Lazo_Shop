using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserPageView : MonoBehaviour
{
    [SerializeField] private TMP_Text nickname;
    [SerializeField] private TMP_Text city;
    [SerializeField] private TMP_Text spent;
    [SerializeField] private TMP_Text email;
    [SerializeField] private TMP_Text phoneNumber;
    [SerializeField] private Button exitButton;
    
    public void Show(UserData userData)
    {
        nickname.text = userData.nickname;
        city.text = userData.city;
        spent.text = userData.spent.ToString();
        email.text = userData.email;
        phoneNumber.text = userData.phoneNumber;
        exitButton.onClick.AddListener(() => gameObject.SetActive(false));
        gameObject.SetActive(true);
    }
}
