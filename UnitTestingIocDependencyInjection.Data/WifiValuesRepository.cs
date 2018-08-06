namespace UnitTestingIocDependencyInjection.Data
{
    public class WifiValuesRepository : IValuesRepository
    {
        public string GetById(int id)
        {
            switch (id)
            {
                case 1:
                    return "{\"name\":\"LAX\"}";
                case 2:
                    return "{\"name\":\"DTW\"}";
                case 3:
                    return "{\"name\":\"SMO\"}";
                default:
                    return "{\"name\":\"DNE\"}";
            }
        }
    }
}
