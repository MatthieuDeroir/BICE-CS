using BICE.DAL;
using BICE.DTO;
using BICE.BLL;


public class VehicleService
{
    private readonly Vehicle_Repository _vehicleRepository;

    public VehicleService(Vehicle_Repository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public Vehicle_DTO AddVehicle(Vehicle_DTO vehicleDto)
    {
        var vehicleBll = new Vehicle_BLL(vehicleDto.InternalNumber, vehicleDto.Denomination, vehicleDto.LicensePlate, vehicleDto.IsActive);
        var vehicleDal = new Vehicle_DAL(vehicleBll);
        var addedVehicleDal = _vehicleRepository.Insert(vehicleDal);

        return new Vehicle_DTO
        {
            Id = addedVehicleDal.Id,
            InternalNumber = addedVehicleDal.InternalNumber,
            Denomination = addedVehicleDal.Denomination,
            LicensePlate = addedVehicleDal.LicensePlate,
            IsActive = addedVehicleDal.IsActive
        };
    }
}