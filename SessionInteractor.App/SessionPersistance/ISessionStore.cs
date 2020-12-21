using System.Collections.Generic;

namespace SessionPersistence
{
    public interface ISessionStore
    {
        List<SessionValue> Store { get; set; }
    }
}