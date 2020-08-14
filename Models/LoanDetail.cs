using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoanManagement.Models
{
    public class LoanDetail
    {
        public string BorrowerName { get; set; }
        //Loan/Lien information
        [Key]
        public int LoanId { get; set; } //should be primary key
        public int LoanTerm { get; set; }
        public int LoanAmount{ get; set; }
        public string LoanType { get; set; }

        //Property Information
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        //Legal Document
        public string LegalInformation { get; set; }

    }
}
