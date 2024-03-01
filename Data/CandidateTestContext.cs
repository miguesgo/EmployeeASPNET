using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CandidateTest.Models;

namespace CandidateTest.Data
{
    public class CandidateTestContext : DbContext
    {
        public CandidateTestContext (DbContextOptions<CandidateTestContext> options)
            : base(options)
        {
        }

        public DbSet<CandidateTest.Models.Employees> Employees { get; set; } = default!;
    }
}
