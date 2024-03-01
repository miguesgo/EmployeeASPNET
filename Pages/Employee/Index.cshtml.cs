using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateTest.Data;
using CandidateTest.Models;

namespace CandidateTest.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly CandidateTest.Data.CandidateTestContext _context;

        public IndexModel(CandidateTest.Data.CandidateTestContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employees = await _context.Employees.ToListAsync();
            }
        }
    }
}
