using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateTest.Data;
using CandidateTest.Models;

namespace CandidateTest.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly CandidateTest.Data.CandidateTestContext _context;

        public EditModel(CandidateTest.Data.CandidateTestContext context)
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

            var employees =  await _context.Employees.FirstOrDefaultAsync(m => m.ID == id);
            if (employees == null)
            {
                return NotFound();
            }
            Employees = employees;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(Employees.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeesExists(int id)
        {
          return (_context.Employees?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
