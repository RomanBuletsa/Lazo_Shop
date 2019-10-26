using System;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UsersPage
{
    public sealed class  UserView : MonoBehaviour
    {
        public event Action<UserData> UserButtonClicked;
        [SerializeField] private TMP_Text nickname;
        [SerializeField] private TMP_Text city;
        [SerializeField] private TMP_Text spent;
        [SerializeField] private Button userButton;

        public void Show(UserData userData)
        {
            nickname.text = userData.nickname;
            city.text = userData.city;
            spent.text = userData.spent.ToString();
            userButton.onClick.AddListener(() => UserButtonClicked?.Invoke(userData));
        }
    }
}
