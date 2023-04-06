using System;
namespace BICE.DTO
{
    public class Vehicle_DTO : BaseNamedEntity_DTO
    {
        public String InternalNumber { get; set; }
        public String LicensePlate { get; set; }
        public Boolean isActive { get; set; }
    }
}

