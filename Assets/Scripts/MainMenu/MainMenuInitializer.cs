using Application;
using Data;
using SceneManagement;
using UnityEngine;

namespace MainMenu
{
    public sealed class MainMenuInitializer : BaseInitializer
    {
        protected override void Init()
        {
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
