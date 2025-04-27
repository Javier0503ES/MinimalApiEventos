using System;
using ApiEventosCdmx.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiEventosCdmx.Endpoints;

public static class ParkingAccessEndpoints
{
    /// <summary>
    /// MapParkingAccessEndpoints
    /// </summary>
    /// <param name="group">RouteGroupBuilder</param>
    /// <returns>RouteGroupBuilder</returns>
    public static RouteGroupBuilder MapParkingAccessEndpoints(this RouteGroupBuilder group)
    {

        group.MapPost("/AddParkingAccess", AddParkingAccess);
        group.MapPost("/UpdateParkingAccess", UpdateParkingAccess);

        return group;
    }
    /// <summary>
    /// AddParkingAccess
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <param name="accessService">IParkingAccessService</param>
    /// <returns></returns>
    public static async Task<IResult> AddParkingAccess(
        [FromQuery] int idParking,
        [FromQuery] string licensePlateNumber,
        [FromServices] IParkingAccessService accessService)
    {
        var e = await accessService.AddAcesssAsync(idParking, licensePlateNumber.ToUpper());
        return TypedResults.Ok(e);
    }
    /// <summary>
    /// UpdateParkingAccess
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <param name="accessService">IParkingAccessService</param>
    /// <returns></returns>
    public static async Task<IResult> UpdateParkingAccess(
        [FromQuery] int idParking,
        [FromQuery] string licensePlateNumber,
        [FromServices] IParkingAccessService accessService)
    {
        var e = await accessService.UpdateAcesssAsync(idParking, licensePlateNumber.ToUpper());
        return TypedResults.Ok(e);
    }


}
