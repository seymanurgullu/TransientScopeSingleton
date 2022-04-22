using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransientScopeSingleton.Example;

namespace TransientScopeSingleton.Controllers
{
    [ApiController]
    [Route("example")]
    public class WeatherForecastController : ControllerBase
    {
        private ISingleton Singleton;
        //Singleton'da oluşturulan obje hep aynıdır.  
        private IScoped Scoped;
        //SCoped Api'ye request atıldığında obje oluşur. Her request'te yeni obje oluşur
        private ITransient Transient;
        //Transient Her objeye ihtiyaç olduğunda yeni obje oluşturulur.

        private ISingleton Singleton2;
        private IScoped Scoped2;
        private ITransient Transient2;
        public WeatherForecastController(ISingleton Singleton, IScoped Scoped, ITransient Transient, ISingleton Singleton2, IScoped Scoped2, ITransient Transient2)
        {
            this.Singleton = Singleton;
            this.Singleton2 = Singleton2;
            this.Scoped = Scoped;
            this.Scoped2 = Scoped2;
            this.Transient = Transient;
            this.Transient2 = Transient2;
        }
        //singleton ve singleton2 den hep aynı random sayılar döner çünkü
        //bir kez obje create edilir
        [HttpGet("singleton")]
        public int[] SingletonRandom()
        {
            int[] singleton = { Singleton.Random(), Singleton2.Random() };
            return singleton;
        }

        //Array içinde aynı 2 sayı döner fakat her yeni istekte 
       //yeni obje oluştulacağı için her yeni istekte 2 yeni aynı sayı döner
        [HttpGet("scoped")]
        public int[] ScopedRandom()
        {
            int[] scoped = { Scoped.Random(), Scoped2.Random() };
            return scoped;
        }

        //Farklı sayılar döner çünkü her istek yeni bir obje create eder
        [HttpGet("transient")]
        public int[] TransientRandom()
        {
            int[] transient = { Transient.Random(), Transient2.Random() };
            return transient;
        }


    }
}
