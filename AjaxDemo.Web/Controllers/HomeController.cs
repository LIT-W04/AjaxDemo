using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AjaxDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetNumber(int min, int max)
        {
            //{"firstName": "Avrumi", "lastName": "friedman", "age": 35}
            /*
              [{"firstName": "Avrumi", "lastName": "friedman", "age": 35},
                {"firstName": "Avrumi", "lastName": "friedman", "age": 35}]
            
             */
            Thread.Sleep(1000);
            Person person = new Person();
            person.FirstName = "Avrumi";
            person.LastName = "Friedman";
            person.Age = new Random().Next(min, max);
            //for posts: return Json(person);

            return Json(person, JsonRequestBehavior.AllowGet); //for gets we have to do JsonRequestBehavior.AllowGet
        }

        public ActionResult JsonDemo()
        {
            List<Person> people = new List<Person>();
            Person person = new Person();
            person.FirstName = "Avrumi";
            person.LastName = "Friedman";
            person.Age = 35;
            var cars = new List<Car>();
            cars.Add(new Car
            {
                Make = "Lamborghini",
                Model = "Aventador",
                Year = 2017
            });
            cars.Add(new Car
            {
                Make = "Ferarri",
                Model = "458",
                Year = 2017
            });
            cars.Add(new Car
            {
                Make = "McLaren",
                Model = "P1",
                Year = 2017
            });
            person.Cars = cars;
            people.Add(person);
            people.Add(person);
            people.Add(person);
            people.Add(person);

            return Json(people, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OtherJsonDemo()
        {
            return Json(new
            {
                firstName = "Avrumi",
                lastName = "Friedman",
                isCool = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult IsValidEmail(string email)
        {
            return Json(new
            {
                IsValid = email != "foo@bar.com" && email != "hello@world.com"
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Delete(int id)
        {
            //delete record
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}