using Data;
using SceneManagement;

namespace MainMenu
{
    public sealed class MainMenuManager : IManager
    {
        private DataHolder dataHolder;
        public MainMenuManager(DataHolder dataHolder)
        {
            this.dataHolder = dataHolder;
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}
