using System;

namespace ApiEventosCdmx.Services.Interfaces;

public interface IParkingAccessService
{
    Task<bool> AddAcesssAsync(int idParking, string licensePlateNumber);
    Task<bool> UpdateAcesssAsync(int idParking, string licensePlateNumber);

}
