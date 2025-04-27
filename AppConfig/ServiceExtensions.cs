using System;
using ApiEventosCdmx.Infrastructure;
using ApiEventosCdmx.Infrastructure.Interface;
using ApiEventosCdmx.Services;
using ApiEventosCdmx.Services.Interfaces;

namespace ApiEventosCdmx.AppConfig;

public static class ServiceExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
       builder.Services.AddTransient<IParkingService, ParkingService>();
       builder.Services.AddTransient<IReservationService, ReservationService>();
       builder.Services.AddTransient<IParkingAccessService, ParkingAccessService>();

       builder.Services.AddScoped<IParkingData,ParkingRepository>();
         builder.Services.AddScoped<IReservationData, ReservationRepository>();
         builder.Services.AddScoped<IParkingAccessData, ParkingAccessRepository>();

        return builder;

    }
}
