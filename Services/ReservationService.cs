using System;
using ApiEventosCdmx.Entities.ReservationEntities;
using ApiEventosCdmx.Infrastructure.Interface;
using ApiEventosCdmx.Services.Interfaces;

namespace ApiEventosCdmx.Services;
/// <summary>
/// ReservationService
/// </summary>
public class ReservationService : IReservationService
{
    /// <summary>
    /// ReservationService
    /// </summary>
    private readonly IReservationData _cnt;
    /// <summary>
    /// ReservationService builder
    /// </summary>
    /// <param name="repository">IReservationData</param>
    public ReservationService(IReservationData repository)
    {
        _cnt = repository;
    }
    /// <summary>
    /// GetReservationByLicensePlateNumber
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns></returns>
    public async Task<IEnumerable<ReservationDto>> GetReservationByLicensePlateNumber(int idParking,string licensePlateNumber)
    {
        return await _cnt.GetReservationByLicensePlateNumberAsync(idParking,licensePlateNumber);
    }
    /// <summary>
    /// IsReservationActive
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns>bool</returns>
    public async Task<bool> IsReservationActive(int idParking,string licensePlateNumber)
    {
        return await _cnt.IsReservationActive(idParking,licensePlateNumber);
    }
    /// <summary>
    /// AddRecervation
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns>bool</returns>
    public async Task<bool> AddRecervation(int idParking, string licensePlateNumber)
    {
        return await _cnt.AddRecervation(idParking,licensePlateNumber);
    }
}
