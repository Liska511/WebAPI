﻿namespace WebApplication1.DTO.HotelDTO;

public class UpdateHotelDTO
{
    public long Id { get; set; }
    public int CityId { get; set; } // ID города  (Внешний ключ для связи с городом)
    public string HotelName { get; set;} // Имя отеля
    public string HotelDescription { get; set;} // Описание отеля

}