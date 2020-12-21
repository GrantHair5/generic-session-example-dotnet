using System;
using System.Linq;
using Newtonsoft.Json;
using SessionPersistence;

namespace SessionInteractor.Adapters.Output
{
    public interface ISessionRetriever
    {
        T GetValue<T>(Guid id);
    }

    public class SessionRetriever : ISessionRetriever
    {
        private readonly ISessionStore _store;

        public SessionRetriever(ISessionStore store)
        {
            _store = store;
        }

        public T GetValue<T>(Guid id)
        {
            var valueFound = _store.Store.FirstOrDefault(s => s.Id == id);
            return valueFound != null
                ? JsonConvert.DeserializeObject<T>(valueFound.Value) : default;
        }
    }
}