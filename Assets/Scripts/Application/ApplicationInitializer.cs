using Data;
using SceneManagement;
using UnityEngine;

namespace Application
{
    public sealed class ApplicationInitializer : BaseInitializer
    {
        [SerializeField] private DataHolder dataHolder;
        protected override void Init()
        {
            var applicationManager = new ApplicationManager(dataHolder);
        }

        protected override void PostInit() => ApplicationManager.Instance.Start();

        protected override void Deinit() {}
    }
}
