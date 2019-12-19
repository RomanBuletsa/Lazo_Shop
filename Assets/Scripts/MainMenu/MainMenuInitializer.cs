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
            adminPageBtn.onClick.AddListener(() => ScenesLoader.LoadScene(ApplicationScenes.AdminPage.ToString(), true, false));
            userPageBtn.onClick.AddListener(()=> ScenesLoader.LoadScene(ApplicationScenes.UsersPage.ToString(), true, false));
            statisticsPageBtn.onClick.AddListener(()=> ScenesLoader.LoadScene(ApplicationScenes.StatisticsPage.ToString(), true, false));
            var manager = new MainMenuManager();
            ApplicationManager.Instance.RegisterMainMenuManager(manager);
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
