using Application;
using Data;
using SceneManagement;

namespace MainMenu
{
    public sealed class MainMenuManager : IManager
    {

        public void Start()
        {
            ScenesLoader.LoadScene(ApplicationScenes.AdminPage.ToString(), true, false);
            //ScenesLoader.LoadScene(ApplicationScenes.UsersPage.ToString(), true, false);
            //ScenesLoader.LoadScene(ApplicationScenes.StatisticsPage.ToString(), true, false);
            ScenesLoader.UnloadScene(ApplicationScenes.MainMenu.ToString());
        }

        public void Stop()
        {
        }
    }
}
