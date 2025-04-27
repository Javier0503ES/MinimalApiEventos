using System;

namespace ApiEventosCdmx.AppConfig;
/// <summary>
/// SecurityCorsExtensions
/// </summary>
public static class SecurityCorsExtensions
{
    /// <summary>
    /// opcions cors
    /// </summary>
     static string MyAlowSpecificOrigins = "_MyAlowSpecificOrigins";
     /// <summary>
     /// _configuration
     /// </summary>
    private static IConfiguration _configuration;
    /// <summary>
    /// AddSecurityCors
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// <param name="configuration">IConfiguration</param>
    /// <returns>WebApplicationBuilder</returns>
     public static WebApplicationBuilder AddSecurityCors(this WebApplicationBuilder builder , IConfiguration configuration)
    {

                _configuration = configuration;
                builder.Services.AddCors(options => {
                var _o = _configuration.GetSection("AllowedHosts").Get<string[]>();
                options.AddPolicy(name: MyAlowSpecificOrigins, 
                    policy =>
                    {
                        policy.WithOrigins(_o)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
            return builder;
        }

}
