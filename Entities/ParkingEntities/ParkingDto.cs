using System;

namespace ApiEventosCdmx.Entities.ParkingEntities;
/// <summary>
/// ParkingDto
/// </summary>
public class ParkingDto
{
    public int IdParking { get; set; } = default;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal PriceParking { get; set; }
    public int TotalCapacity { get; set; }
    public int TotalSpecialPlace { get; set; }
    public int TotalAvaliablePlace { get; set; }
    public string UrlImg { get; set; } = string.Empty;
    public decimal TotalMoney { get; set; }

}

