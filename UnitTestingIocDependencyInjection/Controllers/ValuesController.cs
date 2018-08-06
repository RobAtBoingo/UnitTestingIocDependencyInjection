using Newtonsoft.Json;
using System.Web.Http;
using UnitTestingIocDependencyInjection.Business;

namespace UnitTestingIocDependencyInjection.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IValues _values;
        public ValuesController(IValues values)
        {
            _values = values;
        }

        public string Get(int id)
        {
            return _values.GetValueById(id).ToString(Formatting.None);
        }
    }
}
