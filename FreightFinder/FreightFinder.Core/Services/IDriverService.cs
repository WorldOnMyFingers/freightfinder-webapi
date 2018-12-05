using FreightFinder.Core.Model;

namespace FreightFinder.Core.Services
{
    public interface IDriverService
    {
        Driver GetDriver(int driverId);
        bool AddNewDriver(Driver driver);
        bool UpdateDriver(Driver driver);
        bool DeleteDriver(int driverId);

    }
}