﻿using System;
using System.Collections.Generic;

namespace ConsoleApp.db.AdventureWorks2017.Models
{
    public partial class SalesTaxRate
    {
        public int SalesTaxRateId { get; set; }
        public int StateProvinceId { get; set; }
        public byte TaxType { get; set; }
        public decimal TaxRate { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual StateProvince StateProvince { get; set; }
    }
}
