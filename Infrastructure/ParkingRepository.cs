using System;
using ApiEventosCdmx.Entities.ParkingEntities;
using ApiEventosCdmx.Infrastructure.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
namespace ApiEventosCdmx.Infrastructure;

/// <summary>
/// ParkingRepository
/// </summary>
/// <param name="configuration">IConfiguration</param>
public class ParkingRepository(IConfiguration configuration) : IParkingData
{
    /// <summary>
    /// _stgCnx connection string
    /// </summary>
    private readonly string _stgCnx = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

    /// <summary>
    /// GetAllParkingAsync
    /// </summary>
    /// <returns>IReadOnlyList<ParkingDto></returns>
    public async Task<IReadOnlyList<ParkingDto>> GetAllParkingAsync()
    {
        try
            {
                using var cnx = new SqlConnection(_stgCnx);
                string query = "select * from dbo.fn_Parking_get()";
                var re = await cnx.QueryAsync<ParkingDto>(query);

                return (List<ParkingDto>)re??new List<ParkingDto>();
            }
            catch
            {
                return new List<ParkingDto>();
            }      
    }
    /// <summary>
    /// ParkingUpdate
    /// </summary>
    /// <param name="parking">ParkingDto</param>
    /// <returns>bool</returns>
    public async Task<bool> ParkingUpdate(ParkingDto parking)
    {
        bool response = default;

        try
            {
                using var cnx = new SqlConnection(_stgCnx);
                var _parameters = new
            {
                    parking.IdParking,
                    Description= parking.Name,
                    parking.Address,
                    parking.PriceParking,
                    parking.TotalCapacity,
                    parking.TotalSpecialPlace,
                    parking.UrlImg
                };
                var _response = await cnx.ExecuteAsync("dbo.sp_Parking_update", _parameters, commandType: System.Data.CommandType.StoredProcedure);
                response = _response == 1;
                return response;
            }
            catch
            {
                return default;
            }
    }

    
}
