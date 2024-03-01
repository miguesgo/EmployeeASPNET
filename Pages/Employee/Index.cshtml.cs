using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateTest.Data;
using CandidateTest.Models;
using Microsoft.Data.SqlClient;

namespace CandidateTest.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly CandidateTest.Data.CandidateTestContext _context;

        public IndexModel(CandidateTest.Data.CandidateTestContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // Retrieve the data stored from Employees
            IQueryable<Employees> EmployeesSort = from eS in _context.Employees select eS;

            // The Employees are sorted by their born date in ascending order
            EmployeesSort = EmployeesSort.OrderBy(eS => eS.BornDate);

            Employees = await EmployeesSort.AsNoTracking().ToListAsync();

        }
    }
}
