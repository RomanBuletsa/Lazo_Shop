using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Application;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UsersPage;

public class UsersPageManager : MonoBehaviour
{
    [SerializeField] private Button searchButton;
    [SerializeField] private TMP_InputField searchField;
    [SerializeField] private UserView userViewsPrefab; 
    [SerializeField] private Transform sceneParent;
    [SerializeField] private UserPageView userPageView;
    [SerializeField] private Button backButton;
    private Dictionary<UserData, UserView> userViews;


    private void Start()
    {
        backButton.onClick.AddListener(UnloadScene);
        searchButton.onClick.RemoveAllListeners();
        searchButton.onClick.AddListener(OnSearchUpBtnClicked);
        ShowUsers();
    }
    
    private void UnloadScene()
    {
        SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());
        SceneManager.UnloadScene(ApplicationScenes.UsersPage.ToString());
    }

    private void OnSearchUpBtnClicked()
    {
        Search(searchField.text);
    }

    public void ShowUsers()
    {
        var userData = ApplicationManager.Instance.DataHolder.GetUsersData();
        userData.Sort( (emp1,emp2)=>emp2.spent.CompareTo(emp1.spent));
        userViews?.Values.ToList().ForEach(v =>
        {
            Destroy(v.gameObject);
        });
        
        userViews=new Dictionary<UserData, UserView>();
        userData.ForEach((u) =>
        {
            var userView = Instantiate(userViewsPrefab, sceneParent);
            userView.Show(u);
            userView.UserButtonClicked += OnSelectedUser;
            userViews.Add(u, userView);
        });
    }

    private void OnSelectedUser(UserData userData)
    {
        userPageView.Show(userData);
    }

    private void Search(string nick)
    {
        foreach (var keyValuePair in userViews)
        {
            keyValuePair.Value.gameObject.SetActive(keyValuePair.Key.nickname.ToLower().Contains(nick.ToLower()));
        }
    }
}
