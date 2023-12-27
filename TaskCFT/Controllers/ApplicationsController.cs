using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskCFT.Services;

namespace TaskCFT.Controllers
{
    public class ApplicationsController : Controller
    {
        private ApplicationService _appService;

        public ApplicationsController(ApplicationService appService)
        {
            _appService = appService;
        }

        // GET: Applications
        public async Task<IActionResult> Index(int? page = 1, int? pageSize = 10)
        {
            ViewBag.Count = _appService.GetTotalCount();

            return View(await _appService.GetListVMsAsync(page ?? 1, pageSize ?? 10));
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var application = await _appService.GetDetailVMAsync(id.Value);
                return View(application);
            }
            catch (Exception)
            {
                return NotFound();
            }

            
        }

    }
}
