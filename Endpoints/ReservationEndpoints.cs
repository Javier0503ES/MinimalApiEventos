using System;
using ApiEventosCdmx.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiEventosCdmx.Endpoints;
/// <summary>
/// ReservationEndpoints
/// </summary>
public static class ReservationEndpoints
{
    /// <summary>
    /// MapReservationEndpoints
    /// </summary>
    /// <param name="group">RouteGroupBuilder</param>
    /// <returns>RouteGroupBuilder</returns>
    public static RouteGroupBuilder MapReservationEndpoints(this RouteGroupBuilder group)
    {
         group.MapGet("/CheckReservationForLicensePlateNumberAsync", CheckReservationForLicensePlateNumberAsync);
         group.MapGet("/GetReservationForLicensePlateNumberAsync", GetReservationForLicensePlateNumberAsync);
         group.MapPost("/AddReservation", AddReservation);

        return group;
    }

    /// <summary>
    /// CheckReservationForLicensePlateNumberAsync
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <param name="reservationService">IReservationService</param>
    /// <returns>bool</returns>
    public static async Task<IResult> CheckReservationForLicensePlateNumberAsync(
        [FromQuery] int idParking,
        [FromQuery] string licensePlateNumber,
        [FromServices] IReservationService reservationService)
    {
        var e = await reservationService.IsReservationActive(idParking,licensePlateNumber.ToUpper());
        return TypedResults.Ok(e);
    }

    /// <summary>
    /// GetReservationForLicensePlateNumberAsync
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <param name="reservationService">IReservationService</param>
    /// <returns>Enumerable<ReservationDto></returns>
    public static async Task<IResult> GetReservationForLicensePlateNumberAsync(
        [FromQuery] int idParking,
        [FromQuery] string licensePlateNumber,
        [FromServices] IReservationService reservationService)
    {
        var e = await reservationService.GetReservationByLicensePlateNumber(idParking,licensePlateNumber.ToUpper());
        return TypedResults.Ok(e);
    }

    /// <summary>
    /// AddReservation
    /// </summary>
    /// <param name="idParking">int</param>
    /// <param name="licensePlateNumber">string</param>
    /// <param name="reservationService"></param>
    /// <returns>bool</returns>
    public static async Task<IResult> AddReservation(
        [FromQuery] int idParking,
        [FromQuery] string licensePlateNumber,
        [FromServices] IReservationService reservationService)
    {
        var e = await reservationService.AddRecervation( idParking,licensePlateNumber.ToUpper());
        return TypedResults.Ok(e);
    }

}
