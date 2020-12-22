using System;
using System.Linq;
using Newtonsoft.Json;
using SessionInteractor.Exceptions;
using SessionPersistence;

namespace SessionInteractor.Adapters.Output.Implementation
{
    public class SessionRetriever : ISessionRetriever
    {
        private readonly ISessionStore _store;

        public SessionRetriever(ISessionStore store)
        {
            _store = store;
        }

        public T GetValue<T>(Guid id)
        {
            var valueFound = _store.Store
                .FirstOrDefault(s =>
                    s.Id == id && s.TimeOutDate > DateTime.UtcNow);

            if (valueFound == null)
            {
                throw new SessionValueExpiredException("Session has expired");
            }

            var valueToReturn = JsonConvert.DeserializeObject<T>(valueFound.Value);
            return valueToReturn;
        }
    }
}