using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PaymentInstruction.Models
{
    public class PaymentInstructionContext : DbContext
    {
        public PaymentInstructionContext(DbContextOptions<PaymentInstructionContext> options)
            : base(options)
        {

        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<BillType> BillTypw { get; set; }
        public DbSet<PaymentInstruction> PaymentInstruction { get; set; }
    }
}
