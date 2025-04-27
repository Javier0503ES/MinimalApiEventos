using System;

namespace ApiEventosCdmx.Entities.ReservationEntities;
/// <summary>
/// ReservationDto
/// </summary>
public class ReservationDto
{
    public int IdReservation { get; set; } 
    public int IdParking { get; set; }
    public string ParkingName { get; set; } = string.Empty;	
    public string LicensePlateNumber { get; set; } 	= string.Empty;
    public int StatusReservation { get; set; } 
    public decimal PriceParking { get; set; }	
    public int IdAccess { get; set; }
    public DateTime ReservationDate { get; set; }
}
