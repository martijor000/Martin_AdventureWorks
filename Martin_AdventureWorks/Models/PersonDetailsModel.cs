﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_AdventureWorks.Models
{
    public class PersonDetailsModel
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Suffix { get; set; }
        public string? PersonType { get; set; }
        public string? EmailPromotion { get; set; }
        public string? AdditionalContactInfo { get; set; }
    }
}
