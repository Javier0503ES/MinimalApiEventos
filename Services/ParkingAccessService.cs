using System;
using ApiEventosCdmx.Infrastructure.Interface;
using ApiEventosCdmx.Services.Interfaces;

namespace ApiEventosCdmx.Services;
/// <summary>
/// ParkingAccessService
/// </summary>
public class ParkingAccessService : IParkingAccessService
{
    /// <summary>
    /// ParkingAccessService
    /// </summary>
    private readonly IParkingAccessData _cnt; 
    /// <summary>
    /// ParkingAccessService
    /// </summary>  
    private readonly IReservationData _reservationData;
    /// <summary>
    /// ParkingAccessService
    /// </summary>
    /// <param name="repository">IParkingAccessData</param>
    /// <param name="reservationData">IReservationData</param>
    public ParkingAccessService(IParkingAccessData repository, IReservationData reservationData)
    {
        _cnt = repository;
        _reservationData = reservationData;
    }
    /// <summary>
    /// AddAcesssAsync
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns>bool</returns>
    public async Task<bool> AddAcesssAsync(int idParking, string licensePlateNumber)
    {       
        var reservation = await _reservationData.GetReservationByLicensePlateNumberAsync(idParking, licensePlateNumber);
        if(reservation.Count == 0 )
        {
            return false;
        }
        var _ite = reservation.Where(q=> q.StatusReservation == 0).FirstOrDefault();
        if(_ite == null)
        {
            return false;
        }
        var exists = await _cnt.addParkingAccess(_ite);
        return exists;
    }
    /// <summary>
    /// UpdateAcesssAsync
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns>bool</returns>
    public async Task<bool> UpdateAcesssAsync(int idParking, string licensePlateNumber)
    {
        var statusAccess = await _cnt.IsActiverAccess(idParking, licensePlateNumber);
        if (statusAccess == false)
        {
            return false;
        }
        var reservations = await _reservationData.GetReservationByLicensePlateNumberAsync(idParking, licensePlateNumber);
         var _reservation = reservations.Where(q=> q.StatusReservation == 1).FirstOrDefault();
        if(_reservation == null)
        {
            return false;
        }
        var exitSucess = await _cnt.UpdateParkingAccess(_reservation); 
        return exitSucess;
        }
}
