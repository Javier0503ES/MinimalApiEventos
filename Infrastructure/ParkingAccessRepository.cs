using System;
using ApiEventosCdmx.Entities.ReservationEntities;
using ApiEventosCdmx.Infrastructure.Interface;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiEventosCdmx.Infrastructure;
/// <summary>
/// ParkingAccessRepository
/// </summary>
/// <param name="configuration">IConfiguration</param>
public class ParkingAccessRepository(IConfiguration configuration) : IParkingAccessData
{
    /// <summary>
    /// _stgCnx connection string
    /// </summary>
    private readonly string _stgCnx = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    /// <summary>
    /// addParkingAccess
    /// </summary>
    /// <param name="reservation">ReservationDto</param>
    /// <returns></returns>
    public async Task<bool> addParkingAccess(ReservationDto reservation)
    {
        bool response = default;

        try
            {
                using var cnx = new SqlConnection(_stgCnx);
                var _parameters = new
                {
                    reservation.IdReservation,
                    reservation.LicensePlateNumber,
                    Price = reservation.PriceParking
                };
                var _response = await cnx.ExecuteAsync("dbo.sp_EntranceAndExit_add", _parameters, commandType: System.Data.CommandType.StoredProcedure);
                
                return _response >0;
            }
            catch
            {
                return response;
            }
    }
    /// <summary>
    /// UpdateParkingAccess
    /// </summary>
    /// <param name="reservation">ReservationDto</param>
    /// <returns>bool</returns>
    public async Task<bool> UpdateParkingAccess(ReservationDto reservation)
    {
       bool response = default;

        try
            {
              using var cnx = new SqlConnection(_stgCnx);
                var _parameters = new
                {
                    IdEntranceAndExit = reservation.IdAccess,
                    reservation.IdReservation,
                    reservation.LicensePlateNumber,
                    reservation.IdParking
                };
                var _response = await cnx.ExecuteAsync("[dbo].[sp_EntranceAndExit_upd]", _parameters, commandType: System.Data.CommandType.StoredProcedure);
                
                return _response >0;
            }
            catch 
            {
                return response;
            }
    }
    /// <summary>
    /// IsActiverAccess
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns>bool</returns>
    public async Task<bool> IsActiverAccess(int idParking,string licensePlateNumber)
    {
        try
            {
                using var cnx = new SqlConnection(_stgCnx);               
                var query = "SELECT dbo.fn_CheckEntranceExist(@IdParking,@LicensePlateNumber)";
                var exists = await cnx.ExecuteScalarAsync<bool>(query, new { IdParking = idParking , LicensePlateNumber = licensePlateNumber });
                return exists;
            }
            catch
            {
                return false;
            }
    }
}
