using System.Web.Http;
using Domain;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    public class ValuesController : ApiController
    {
        public EntitiesModel GetInfo()
        {
            return new ViewModel(Common.DataManager, Common.Manager).Model;
        }
    }
}
