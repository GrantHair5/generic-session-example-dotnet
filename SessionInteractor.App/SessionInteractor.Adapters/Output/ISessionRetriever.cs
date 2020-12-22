using System;

namespace SessionInteractor.Adapters.Output
{
    public interface ISessionRetriever
    {
        T GetValue<T>(Guid id);
    }
}