using Application;
using Data;
using SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public sealed class MainMenuInitializer : BaseInitializer
    {
        [SerializeField] private Button adminPageBtn;
        [SerializeField] private Button userPageBtn;
        [SerializeField] private Button statisticsPageBtn;
        protected override void Init()
        {
            adminPageBtn.onClick.AddListener(LoadAdminPage);
            userPageBtn.onClick.AddListener(LoadUsersPage);
            statisticsPageBtn.onClick.AddListener(LoadStatisticsPage);
            var manager = new MainMenuManager();
            ApplicationManager.Instance.RegisterMainMenuManager(manager);
        }

        private void LoadAdminPage()
        {
            ScenesLoader.LoadScene(ApplicationScenes.AdminPage.ToString());
            ScenesLoader.UnloadScene(ApplicationScenes.MainMenu.ToString());
        }
        
        private void LoadUsersPage()
        {
            ScenesLoader.LoadScene(ApplicationScenes.UsersPage.ToString());
            ScenesLoader.UnloadScene(ApplicationScenes.MainMenu.ToString());
        }
        
        private void LoadStatisticsPage()
        {
            ScenesLoader.LoadScene(ApplicationScenes.StatisticsPage.ToString());
           // ScenesLoader.UnloadScene(ApplicationScenes.MainMenu.ToString());
        }

        protected override void PostInit() => ApplicationManager.Instance.MainMenuManager.Start();

        protected override void Deinit()
        {
            if (ApplicationManager.Instance.MainMenuManager == null) return;
            ApplicationManager.Instance.MainMenuManager.Stop();
            ApplicationManager.Instance.DeregisterMainMenuManager();
        }
    }
}
