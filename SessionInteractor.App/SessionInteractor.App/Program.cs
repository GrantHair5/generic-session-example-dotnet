using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SessionInteractor.Adapters.Input;
using SessionInteractor.Adapters.Input.Implementation;
using SessionInteractor.Adapters.Output;
using SessionInteractor.Domain;
using SessionPersistence;
using SessionPersistence.Implementation;

namespace SessionInteractor.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISessionStore, SessionStore>()
                .AddTransient<ISessionPersister, SessionPersister>()
                .AddTransient<ISessionRetriever, SessionRetriever>()
                .BuildServiceProvider();

            var vehicleOneId = Guid.NewGuid();
            //do the actual work here
            var sessionPersister = serviceProvider.GetService<ISessionPersister>();
            var sessionRetriever = serviceProvider.GetService<ISessionRetriever>();

            sessionPersister.SetValue(new Vehicle
            {
                MakeModel = "Audi A1",
                Registration = "A1"
            }, vehicleOneId);

            var vehicleOne = sessionRetriever.GetValue<Vehicle>(vehicleOneId);

            Console.WriteLine(JsonConvert.SerializeObject(vehicleOne));
        }
    }
}