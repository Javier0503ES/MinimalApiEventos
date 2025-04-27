using ApiEventosCdmx.Entities.ParkingEntities;
namespace ApiEventosCdmx.Services.Interfaces;

public interface IParkingService
{
    Task<IEnumerable<ParkingDto>> GetAllParkingsAsync();

    Task<bool> ParkingUpdate(ParkingDto parking);

}
