using System;
using Runtime.Domains.Locales;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<LocaleEntity>(Lifetime.Singleton);
        builder.Register<LocalePresenter>(Lifetime.Singleton);
    }

    private void Start()
    {
        Container.Resolve<LocalePresenter>().Initialize();
    }
}
