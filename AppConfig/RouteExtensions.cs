using System;
using ApiEventosCdmx.Endpoints;

namespace ApiEventosCdmx.AppConfig;
/// <summary>
/// RouteExtensions
/// </summary>
public static class RouteExtensions
{
    /// <summary>
    /// AddRoutes
    /// </summary>
    /// <param name="app">WebApplication</param>
    /// <returns>WebApplication</returns>
    public static WebApplication AddRoutes(this WebApplication app)
    {
        app.MapGroup("ParkingEndpoint").MapParkingEndpoints().WithTags("G_Parking");
        app.MapGroup("ReservationEndpoint").MapReservationEndpoints().WithTags("G_Reservation");
        app.MapGroup("ParkingAccessEndpoint").MapParkingAccessEndpoints().WithTags("G_ParkingAccess");
        return app;
    }

}
