using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentInstruction.Models
{
    public class PaymentInstruction
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int BillTypeId { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryBICCode { get; set; }
    }
}
