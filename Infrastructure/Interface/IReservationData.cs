using System;
using ApiEventosCdmx.Entities.ReservationEntities;

namespace ApiEventosCdmx.Infrastructure.Interface;

public interface IReservationData
{
    Task<bool> IsReservationActive(int idParking,string licensePlateNumber);

    Task<IReadOnlyList<ReservationDto>> GetReservationByLicensePlateNumberAsync(int idParking,string licensePlateNumber);

    Task<bool> AddRecervation(int idParking,string licensePlateNumber);



}
