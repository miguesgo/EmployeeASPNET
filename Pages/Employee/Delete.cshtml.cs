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
    public class DeleteModel : PageModel
    {
        private readonly CandidateTest.Data.CandidateTestContext _context;

        public DeleteModel(CandidateTest.Data.CandidateTestContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Employees Employees { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.FirstOrDefaultAsync(m => m.ID == id);

            if (employees == null)
            {
                return NotFound();
            }
            else 
            {
                Employees = employees;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var employees = await _context.Employees.FindAsync(id);

            if (employees != null)
            {
                Employees = employees;
                _context.Employees.Remove(Employees);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
