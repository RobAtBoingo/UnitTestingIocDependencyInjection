namespace UnitTestingIocDependencyInjection.Data
{
    public class BroadbandValuesRepository : IValuesRepository
    {
        public string GetById(int id)
        {
            switch (id)
            {
                case 1:
                    return "{\"name\":\"Dirk\"}";
                case 2:
                    return "{\"name\":\"Digg\"}";
                case 3:
                    return "{\"name\":\"Laer\"}";
                default:
                    return "{\"name\":\"DNE\"}";
            }
        }
    }
}
