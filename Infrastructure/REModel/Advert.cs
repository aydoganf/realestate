using System;

namespace REModel
{
    public class Advert
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Area { get; set; }
        public int Age { get; set; }
        public string HeatingType { get; set; }
        public string RoomHallValue { get; set; }
        public string MarketingType { get; set; }
        public string EstateType { get; set; }
        public string ParentEstateType { get; set; }
        public string Floor { get; set; }
        public string AdvertType { get; set; }
        public int BathCount { get; set; }
        public int FloorCount { get; set; }
        public decimal Deposit { get; set; }
        public string DepositCurrency { get; set; }
        public decimal Price { get; set; }
        public string PriceCurrency { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AdvertNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string GAddress { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public string AdvertOwnerType { get; set; }
        public bool IsFlatForLandMethod { get; set; }
        public string CreditType { get; set; }
        public string DeedType { get; set; }
        public bool IsExchangable { get; set; }
        public string FuelType { get; set; }
        public string IsSublease { get; set; }
        public string AdvertStatus { get; set; }
        public string AdvertUsingType { get; set; }
        public string StarCount { get; set; }
        public int BadCount { get; set; }
        public int RoomCount { get; set; }
        public Guid ProcejtId { get; set; }
        public bool Deleted { get; set; }
    }
}
