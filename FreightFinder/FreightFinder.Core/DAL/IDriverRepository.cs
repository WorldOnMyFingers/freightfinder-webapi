using FreightFinder.Core.Model;

namespace FreightFinder.Core.DAL
{
    public interface IDriverService
    {
        Driver GetDriver(int driverId);
        bool AddNewDriver(Driver driver);
        bool UpdateDriver(Driver driver);
        bool DeleteDriver(int driverId);

    }
}