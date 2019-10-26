using UnityEngine;

namespace SceneManagement
{
    public abstract class BaseInitializer : MonoBehaviour
    {
        private void Awake()
        {
            if (BaseInitializer.IsApplicationNotInitialized())
            {
                ScenesLoader.LoadScene(0, true, false, false);
            }
            else
            {
                Debug.Log((object) ("[BaseInitializer]: Initializing " + this.gameObject.name + "..."));
                this.Init();
            }
        }

        private void Start()
        {
            this.PostInit();
        }

        private void OnDestroy()
        {
            Debug.Log((object) ("[BaseInitializer]: Deinitializing " + this.gameObject.name + "..."));
            this.Deinit();
        }

        protected abstract void Init();

        protected abstract void PostInit();

        protected abstract void Deinit();

        private static bool IsApplicationNotInitialized()
        {
            if (!BaseApplicationManager.IsInitialized)
                return (uint) ScenesLoader.CurrentSceneIndex > 0U;
            return false;
        }
    }
}
