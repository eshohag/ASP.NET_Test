using ASP.NET_Test.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Services_API.Controllers
{
    public class ServicesController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Student> Get()
        {
            var all = db.Students.ToList();
            return all;
        }
    }
}
