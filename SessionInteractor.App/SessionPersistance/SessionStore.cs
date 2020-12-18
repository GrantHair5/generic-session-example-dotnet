using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SessionPersistence
{
    public class SessionValue
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public string TypeOfValue { get; set; }
    }

    public static class SessionStore
    {
        public static List<SessionValue> Store = new List<SessionValue>();

        public static void SetValue<T>(T value, Guid id)
        {
            var valueFound = Store.FirstOrDefault(s => s.Id == id);
            if (valueFound == null)
            {
                Store.Add(new SessionValue
                {
                    Id = id,
                    Value = JsonConvert.SerializeObject(value),
                    TypeOfValue = value.GetType().Name
                });
            }
            else
            {
                valueFound.Value = JsonConvert.SerializeObject(value);
            }

            PrintSessionToConsole();
        }

        public static T GetValue<T>(Guid id)
        {
            var valueFound = Store.FirstOrDefault(s => s.Id == id);
            return valueFound != null ? JsonConvert.DeserializeObject<T>(valueFound.Value) : default;
        }

        public static void PrintSessionToConsole()
        {
            Console.WriteLine(JsonConvert.SerializeObject(Store, Formatting.Indented));
        }
    }
}