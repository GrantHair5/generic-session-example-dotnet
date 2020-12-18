using System;

namespace SessionInteractor.Adapters.Input
{
    public interface ISessionPersister
    {
        void SetValue<T>(T value, Guid id);
    }
}