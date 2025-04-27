using System;
using ApiEventosCdmx.Entities.ReservationEntities;

namespace ApiEventosCdmx.Infrastructure.Interface;

public interface IParkingAccessData
{
    Task<bool> addParkingAccess (ReservationDto reservation);
    Task<bool> UpdateParkingAccess (ReservationDto reservation);
    Task<bool> IsActiverAccess(int idParking,string licensePlateNumber);

}
