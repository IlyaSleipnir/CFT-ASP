using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using TaskCFT.Data;
using TaskCFT.Models.Entities;
using TaskCFT.Models.ViewModels.WorkRequestVM;
using TaskCFT.Services;

namespace TaskCFT.Controllers
{
    public class WorkRequestsController : Controller
    {
        private WorkRequestService _workRequstService;
        public WorkRequestsController(WorkRequestService workRequstService)
        {
            _workRequstService = workRequstService;
        }

        // GET: WorkRequests
        public async Task<IActionResult> Index(int? page = 1, int? pageSize = 10)
        {
            ViewBag.Count = _workRequstService.GetTolalCount();

            return View(await _workRequstService.GetListVMsAsync(page ?? 1, pageSize ?? 10));

        }

        // GET: WorkRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var workRequest = await _workRequstService.GetDetailVMAsync(id.Value);
                return View(workRequest);
            }
            catch(Exception)
            {
                return NotFound();
            }

        }

        // GET: WorkRequests/Create
        public IActionResult Create()
        {
            return View(new WorkRequestDataVM { ApplicationsList = _workRequstService.GetSelectedList() });
        }

        // POST: WorkRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,EndDate,Email,ApplicationId")] WorkRequestDataVM workRequest)
        {
            if (ModelState.IsValid)
            {

                if (!await _workRequstService.CreateAsync(workRequest))
                {
                    return NotFound(); 
                }

                return RedirectToAction(nameof(Index));
            }

            workRequest.ApplicationsList = _workRequstService.GetSelectedList();

            return View(workRequest);
        }

        // GET: WorkRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var workRequest = await _workRequstService.GetDataVMAsync(id.Value);
                return View(workRequest);
            }
            catch(Exception)
            {
                return NotFound();
            }

        }

        // POST: WorkRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,EndDate,Email,ApplicationId")] WorkRequestDataVM workRequest)
        {
            if (id != workRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!await _workRequstService.EditAsync(workRequest))
                    {
                        return NotFound();
                    }
                }
                catch(Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            try
            {
                return View(await _workRequstService.GetDataVMAsync(workRequest.Id));
            }
            catch(Exception)
            {
                return NotFound();
            }

        }

        // GET: WorkRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var workRequest = await _workRequstService.GetDataVMAsync(id.Value);
                return View(workRequest);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: WorkRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _workRequstService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
