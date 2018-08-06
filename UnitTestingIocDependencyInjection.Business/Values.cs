using Newtonsoft.Json.Linq;
using UnitTestingIocDependencyInjection.Data;

namespace UnitTestingIocDependencyInjection.Business
{
    public class Values : IValues
    {
        private readonly IValuesRepository _valuesRepository;

        public Values(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository;
        }

        public JToken GetValueById(int id)
        {
            var value = _valuesRepository.GetById(id);
            try
            {
                var valueAsJson = JToken.Parse(value);
                return valueAsJson["name"].ToString() == "DNE" 
                    ? JToken.Parse("{\"error\":\"ID:" + id + " does not exist.\"}") 
                    : valueAsJson;
            }
            catch
            {
                return JToken.Parse("{\"error\":\"SOLR!\"}");
            }
        }
    }
}
