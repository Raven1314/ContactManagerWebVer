using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactManagerWebVer.Data;
using ContactManagerWebVer.Models;
using HarrisContactWebVer.Models;

namespace ContactManagerWebVer.Controllers
{
    public class PersonalContactsController : Controller
    {
        private readonly ContactDbContext _context;

        public PersonalContactsController(ContactDbContext context)
        {
            _context = context;
        }

        // GET: PersonalContacts
        public async Task<IActionResult> Index(string search)
        {
            /// <summary>
            /// Contact search, code resued from  RapidLaunch project 
            /// </summary>
            ViewData["ContactFilter"] = search;
            var contactFilter = from s in _context.PersonalContacts
                              select s;
            if (!String.IsNullOrEmpty(search))
            {
                contactFilter = contactFilter.Where(s => s.PFname.Contains(search) || s.PLname.Contains(search) || s.PerTel.Contains(search) || s.PEmail.Contains(search));//searth the text that have been passed from the index 
            }
            return View(await contactFilter.AsNoTracking().ToListAsync());

            // return View(await _context.PersonalContacts.ToListAsync());
        }

        // GET: PersonalContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.PersonalContacts
                .FirstOrDefaultAsync(m => m.PersonalContactID == id);
            if (personalContact == null)
            {
                return NotFound();
            }

            return View(personalContact);
        }

        // GET: PersonalContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalContactID,PFname,PLname,PEmail,PerTel,PAddr1,PAddr2,PAddr3,PPostcode,PCity")] PersonalContact personalContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalContact);
        }

        // GET: PersonalContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.PersonalContacts.FindAsync(id);
            if (personalContact == null)
            {
                return NotFound();
            }
            return View(personalContact);
        }

        // POST: PersonalContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalContactID,PFname,PLname,PEmail,PerTel,PAddr1,PAddr2,PAddr3,PPostcode,PCity")] PersonalContact personalContact)
        {
            if (id != personalContact.PersonalContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalContactExists(personalContact.PersonalContactID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personalContact);
        }

        // GET: PersonalContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.PersonalContacts
                .FirstOrDefaultAsync(m => m.PersonalContactID == id);
            if (personalContact == null)
            {
                return NotFound();
            }

            return View(personalContact);
        }

        // POST: PersonalContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalContact = await _context.PersonalContacts.FindAsync(id);
            _context.PersonalContacts.Remove(personalContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
            }
            private bool PersonalContactExists(int id)
        {
            return _context.PersonalContacts.Any(e => e.PersonalContactID == id);
        }


    }
}
