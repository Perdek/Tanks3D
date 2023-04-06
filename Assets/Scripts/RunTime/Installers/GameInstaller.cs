using RunTime.Communicators.LoadingSceneCommunicator;
using Zenject;

namespace RunTime.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILoadingSceneCommunicator>().To<LoadingSceneCommunicator>().AsSingle();
        }
    }
}