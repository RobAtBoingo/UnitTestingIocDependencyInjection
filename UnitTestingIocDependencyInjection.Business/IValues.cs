using Newtonsoft.Json.Linq;

namespace UnitTestingIocDependencyInjection.Business
{
    public interface IValues
    {
        JToken GetValueById(int id);
    }
}
