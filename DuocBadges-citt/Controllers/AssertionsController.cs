using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuocBadges.Models;

namespace DuocBadges.Controllers
{
    public class AssertionsController : Controller
    {
        private readonly DuocBadgesContext _context;

        public AssertionsController(DuocBadgesContext context)
        {
            _context = context;
        }

        // GET: Assertions
        public async Task<IActionResult> Index()
        {
            var duocBadgesContext = _context.Assertions.Include(a => a.Badge).Include(a => a.Evidence).Include(a => a.Recipient).Include(a => a.Verification);
            return View(await duocBadgesContext.ToListAsync());
        }

        // GET: Assertions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assertions = await _context.Assertions
                .Include(a => a.Badge)
                .Include(a => a.Evidence)
                .Include(a => a.Recipient)
                .Include(a => a.Verification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assertions == null)
            {
                return NotFound();
            }

            return View(assertions);
        }

        // GET: Assertions/Create
        public IActionResult Create()
        {
            ViewData["BadgeId"] = new SelectList(_context.Badge, "Id", "Id");
            ViewData["EvidenceId"] = new SelectList(_context.Evidence, "Id", "Id");
            ViewData["RecipientId"] = new SelectList(_context.IdentityObject, "Id", "Id");
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id");
            return View();
        }

        // POST: Assertions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,RecipientId,BadgeId,VerificationId,IssuedOn,Image,EvidenceId,Narrative,Expires,Revoked,RevocationReason")] Assertions assertions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assertions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BadgeId"] = new SelectList(_context.Badge, "Id", "Id", assertions.BadgeId);
            ViewData["EvidenceId"] = new SelectList(_context.Evidence, "Id", "Id", assertions.EvidenceId);
            ViewData["RecipientId"] = new SelectList(_context.IdentityObject, "Id", "Id", assertions.RecipientId);
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id", assertions.VerificationId);
            return View(assertions);
        }

        // GET: Assertions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assertions = await _context.Assertions.FindAsync(id);
            if (assertions == null)
            {
                return NotFound();
            }
            ViewData["BadgeId"] = new SelectList(_context.Badge, "Id", "Id", assertions.BadgeId);
            ViewData["EvidenceId"] = new SelectList(_context.Evidence, "Id", "Id", assertions.EvidenceId);
            ViewData["RecipientId"] = new SelectList(_context.IdentityObject, "Id", "Id", assertions.RecipientId);
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id", assertions.VerificationId);
            return View(assertions);
        }

        // POST: Assertions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Type,RecipientId,BadgeId,VerificationId,IssuedOn,Image,EvidenceId,Narrative,Expires,Revoked,RevocationReason")] Assertions assertions)
        {
            if (id != assertions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assertions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssertionsExists(assertions.Id))
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
            ViewData["BadgeId"] = new SelectList(_context.Badge, "Id", "Id", assertions.BadgeId);
            ViewData["EvidenceId"] = new SelectList(_context.Evidence, "Id", "Id", assertions.EvidenceId);
            ViewData["RecipientId"] = new SelectList(_context.IdentityObject, "Id", "Id", assertions.RecipientId);
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id", assertions.VerificationId);
            return View(assertions);
        }

        // GET: Assertions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assertions = await _context.Assertions
                .Include(a => a.Badge)
                .Include(a => a.Evidence)
                .Include(a => a.Recipient)
                .Include(a => a.Verification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assertions == null)
            {
                return NotFound();
            }

            return View(assertions);
        }

        // POST: Assertions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var assertions = await _context.Assertions.FindAsync(id);
            _context.Assertions.Remove(assertions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssertionsExists(string id)
        {
            return _context.Assertions.Any(e => e.Id == id);
        }
    }
}
