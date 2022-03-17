using UnityEngine;
using Zenject;

public class SessionInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<ISessionController>()
            .To<SessionController>()
            .AsSingle()
            .NonLazy();
    }
}
