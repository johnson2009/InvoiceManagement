using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.API.Contract.DTO
{
    public class InvoiceDto
    {
        public Guid InvoiceID{get;set;}

        public string InvoiceNumber{get;set;}

        public DateTime InvoiceDate{get;set;}

        public string DueDate{get;set;}

        public string CustomerName{get;set;}

        public string CustomerAddress{get;set;}

        public string CustomerEmail{get;set;}

        public string CustomerPhone{get;set;}

        public string CustomerTaxID{get;set;}

        public decimal InvoiceAmount{get;set;}

    }
}