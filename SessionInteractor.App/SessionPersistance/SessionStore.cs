using System;
using System.Collections.Generic;

namespace SessionPersistence
{
    public class SessionValue
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public string TypeOfValue { get; set; }
    }

    public class SessionStore : ISessionStore
    {
        public List<SessionValue> Store { get; set; }
    }
}