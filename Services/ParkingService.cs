using System;
using ApiEventosCdmx.Entities.ParkingEntities;
using ApiEventosCdmx.Infrastructure.Interface;
using ApiEventosCdmx.Services.Interfaces;

namespace ApiEventosCdmx.Services;
/// <summary>
/// ParkingService
/// </summary>
public class ParkingService : IParkingService
{
    /// <summary>
    /// ParkingService
    /// </summary>
    private readonly IParkingData _cnt;
    /// <summary>
    /// ParkingService builder
    /// </summary>
    /// <param name="repository">IParkingData</param>
    public ParkingService(IParkingData repository)
    {
        _cnt = repository;
    }
    /// <summary>
    /// GetAllParkingsAsync
    /// </summary>
    /// <returns>IEnumerable<ParkingDto></returns>
    public async Task<IEnumerable<ParkingDto>> GetAllParkingsAsync()
    {
         return await _cnt.GetAllParkingAsync();
    }
    /// <summary>
    /// ParkingUpdate
    /// </summary>
    /// <param name="parking">ParkingDto</param>
    /// <returns>bool</returns>
    public async Task<bool> ParkingUpdate(ParkingDto parking)
    {
         return await _cnt.ParkingUpdate(parking);
    }
}
