using AdminPage;
using Data;
using MainMenu;
using SceneManagement;
using UnityEngine.SceneManagement;

namespace Application
{
    public sealed class ApplicationManager : BaseApplicationManager
    {
        public static ApplicationManager Instance { get; private set; }
        
        public MainMenuManager MainMenuManager { get; private set; }

        public AdminPageManager AdminPageManager { get; set; }

        public DataHolder DataHolder { get; private set; }

        public ApplicationManager(DataHolder dataHolder)
        {
            Instance = this;
            IsInitialized = true;
            DataHolder = dataHolder;
        }

        public override void Start()
        {
            ScenesLoader.LoadScene(ApplicationScenes.MainMenu.ToString(), true, false);
            ScenesLoader.UnloadScene(ApplicationScenes.ApplicationInitializer.ToString());
        }

        public override void Stop()
        {
        }

        public void RegisterMainMenuManager(MainMenuManager mainMenuManager) => MainMenuManager = mainMenuManager;
        public void DeregisterMainMenuManager() => MainMenuManager = null;
    }
}