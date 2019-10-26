using SceneManagement;

namespace Application
{
    public sealed class ApplicationInitializer : BaseInitializer
    {
        protected override void Init()
        {
            var applicationManager = new ApplicationManager();
        }

        protected override void PostInit() => ApplicationManager.Instance.Start();

        protected override void Deinit() {}
    }
}
