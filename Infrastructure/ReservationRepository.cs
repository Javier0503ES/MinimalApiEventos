using ApiEventosCdmx.Entities.ReservationEntities;
using ApiEventosCdmx.Infrastructure.Interface;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiEventosCdmx.Infrastructure;
/// <summary>
/// ReservationRepository
/// </summary>
/// <param name="configuration">IConfiguration</param>
public class ReservationRepository(IConfiguration configuration) : IReservationData
{
    /// <summary>
    /// _stgCnx connection string
    /// </summary>
    private readonly string _stgCnx = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    /// <summary>
    /// GetReservationByLicensePlateNumberAsync
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns>IReadOnlyList<ReservationDto></returns>
    public async Task<IReadOnlyList<ReservationDto>> GetReservationByLicensePlateNumberAsync(int idParking,string licensePlateNumber)
    {
        try
            {
                using var cnx = new SqlConnection(_stgCnx);
                string query = $"select * from dbo.fn_ReservationsByLicensePlate({idParking},'{licensePlateNumber}') ";
                var response = await cnx.QueryAsync<ReservationDto>(query);

                return (List<ReservationDto>)response??new List<ReservationDto>();
            }
            catch
            {
                return new List<ReservationDto>();
            }
    }
    /// <summary>
    /// IsReservationActive
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns></returns>
    public async Task<bool> IsReservationActive(int idParking,string licensePlateNumber)
    {
        try
            {
                using var cnx = new SqlConnection(_stgCnx);               
                var query = "SELECT dbo.fn_CheckReservationExist(@IdParking,@LicensePlateNumber)";
                var exists = await cnx.ExecuteScalarAsync<bool>(query, new { IdParking = idParking , LicensePlateNumber = licensePlateNumber });
                return exists;
            }
            catch 
            {
                return false;
            }
    }
    /// <summary>
    /// AddRecervation
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <returns>bool</returns>
    public async Task<bool> AddRecervation(int idParking,string licensePlateNumber)
    {
        try
            {
                using var cnx = new SqlConnection(_stgCnx);
                var _parameters = new
                {
                    IdParking = idParking,
                    LicensePlateNumber = licensePlateNumber
                };
                var _response = await cnx.ExecuteAsync("[dbo].[sp_Reservation_add]", _parameters, commandType: System.Data.CommandType.StoredProcedure);
                
                return _response >0;
            }
            catch
            {
                return false;
            }
    }
}
