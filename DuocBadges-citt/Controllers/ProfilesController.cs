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
    public class ProfilesController : Controller
    {
        private readonly DuocBadgesContext _context;

        public ProfilesController(DuocBadgesContext context)
        {
            _context = context;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            var duocBadgesContext = _context.Profile.Include(p => p.Cripto).Include(p => p.RevocationList).Include(p => p.Verification);
            return View(await duocBadgesContext.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .Include(p => p.Cripto)
                .Include(p => p.RevocationList)
                .Include(p => p.Verification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            ViewData["CriptoId"] = new SelectList(_context.CriptoKey, "Id", "Id");
            ViewData["RevocationListId"] = new SelectList(_context.Revocations, "Id", "Id");
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id");
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Name,Url,Telephone,Description,Image,Email,CriptoId,VerificationId,RevocationListId")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CriptoId"] = new SelectList(_context.CriptoKey, "Id", "Id", profile.CriptoId);
            ViewData["RevocationListId"] = new SelectList(_context.Revocations, "Id", "Id", profile.RevocationListId);
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id", profile.VerificationId);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            ViewData["CriptoId"] = new SelectList(_context.CriptoKey, "Id", "Id", profile.CriptoId);
            ViewData["RevocationListId"] = new SelectList(_context.Revocations, "Id", "Id", profile.RevocationListId);
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id", profile.VerificationId);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Type,Name,Url,Telephone,Description,Image,Email,CriptoId,VerificationId,RevocationListId")] Profile profile)
        {
            if (id != profile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.Id))
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
            ViewData["CriptoId"] = new SelectList(_context.CriptoKey, "Id", "Id", profile.CriptoId);
            ViewData["RevocationListId"] = new SelectList(_context.Revocations, "Id", "Id", profile.RevocationListId);
            ViewData["VerificationId"] = new SelectList(_context.Verification, "Id", "Id", profile.VerificationId);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .Include(p => p.Cripto)
                .Include(p => p.RevocationList)
                .Include(p => p.Verification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profile = await _context.Profile.FindAsync(id);
            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(string id)
        {
            return _context.Profile.Any(e => e.Id == id);
        }
    }
}
