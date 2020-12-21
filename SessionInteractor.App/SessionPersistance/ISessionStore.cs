using System.Collections.Generic;
using SessionPersistence.Implementation;

namespace SessionPersistence
{
    public interface ISessionStore
    {
        List<SessionValue> Store { get; set; }
    }
}