using System;
using Newtonsoft.Json;
using SessionInteractor.Domain;
using SessionPersistence;

namespace SessionInteractor.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the session interactor");

            var GrantId = Guid.NewGuid();
            var DioId = Guid.NewGuid();
            var car1Id = Guid.NewGuid();

            SessionStore.SetValue(new Person
            {
                Name = "Grant"
            }, GrantId);

            var grant = SessionStore.GetValue<Person>(GrantId);

            Console.WriteLine(grant.Name);

            SessionStore.SetValue(new Person
            {
                Name = "Dio"
            }, DioId);

            SessionStore.SetValue(new Vehicle
            {
                MakeModel = "Mazda Miata 1.4L",
                Registration = "B1G B4LL5"
            }, car1Id);

            var diosCar = SessionStore.GetValue<Vehicle>(car1Id);

            Console.WriteLine(JsonConvert.SerializeObject(diosCar, Formatting.Indented));

            Console.ReadLine();
        }
    }
}