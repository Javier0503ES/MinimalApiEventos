using System;
using ApiEventosCdmx.Entities.ReservationEntities;

namespace ApiEventosCdmx.Services.Interfaces;

public interface IReservationService
{
    /// <summary>
    /// Determines whether a reservation associated with the specified license plate number is currently active.
    /// </summary>
    /// <param name="licensePlateNumber">The license plate number to check for an active reservation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a boolean value:
    /// <c>true</c> if the reservation is active; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> IsReservationActive(int idParking,string licensePlateNumber);

    Task<IEnumerable<ReservationDto>> GetReservationByLicensePlateNumber(int idParking,string licensePlateNumber);

    Task<bool> AddRecervation(int idParking,string licensePlateNumber);
}
