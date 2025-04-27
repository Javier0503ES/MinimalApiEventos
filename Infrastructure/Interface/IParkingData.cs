using ApiEventosCdmx.Entities.ParkingEntities;

namespace ApiEventosCdmx.Infrastructure.Interface;

public interface IParkingData
{
Task<IReadOnlyList<ParkingDto>> GetAllParkingAsync();
Task<bool> ParkingUpdate(ParkingDto parking);
}
