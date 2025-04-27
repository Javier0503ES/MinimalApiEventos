using System;
using ApiEventosCdmx.Entities.ParkingEntities;
using ApiEventosCdmx.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ApiEventosCdmx.Endpoints;
/// <summary>
/// ParkingEndPoints
/// </summary>
public static class ParkingEndPoints
{
    /// <summary>
    /// MapParkingEndpoints
    /// </summary>
    /// <param name="group">RouteGroupBuilder</param>
    /// <returns>RouteGroupBuilder</returns>
    public static RouteGroupBuilder MapParkingEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/GetAllParking", GetAllParking);
        group.MapPut("/UpdateparkingInfo", UpdateparkingInfo);

        return group;
    }
    /// <summary>
    /// GetAllParking
    /// </summary>
    /// <param name="parkingService">IParkingService</param>
    /// <returns>IEnumerable<ParkingDto></returns>
    public static async Task<IResult> GetAllParking([FromServices] IParkingService parkingService)
    {
        var e = await parkingService.GetAllParkingsAsync();
        return TypedResults.Ok(e);
    }
    /// <summary>
    /// UpdateparkingInfo
    /// </summary>
    /// <param name="item">ParkingDto</param>
    /// <param name="parkingService">IParkingService</param>
    /// <returns>bool</returns>
    public static async Task<IResult> UpdateparkingInfo(
        [FromBody] ParkingDto item,
        [FromServices] IParkingService parkingService)
    {
        try
        {
            if (item == null)
            {
                return TypedResults.BadRequest("Invalid parking data.");
            }
            var e = await parkingService.ParkingUpdate(item);
            return TypedResults.Ok(e);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"Error: {ex.Message}");
        }
    }



}
