using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDTO:IDto
    {
        public int RentId { get; set; }
        public string CarDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
       
    }
}
