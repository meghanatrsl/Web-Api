using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Trainee.Controllers
{
   
    public class TraineeController : ApiController
    {
        List<Trainee> names = new List<Trainee>
        {
            new Trainee{Id =0, Name="abc",Age=10},
            new Trainee{Id =1, Name="xyz",Age=11},
           
        };

        public List<Trainee> Get()
        {
            return names;
        }

        public IHttpActionResult Post(Trainee trainee)
        {
            names.Add(trainee);
            return Ok(names);
        }

        public List<Trainee> Put(Trainee trainee)
        {
            if (trainee == null)
            {
                throw new ArgumentNullException("trainee");
            }
            int index = names.FindIndex(p => p.Id == trainee.Id);
            if (index == -1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                names.RemoveAt(index);
                names.Add(trainee);
                return names;
            }



        }
    }
    public class Trainee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
    }
}
