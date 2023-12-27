using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskCFT.Data;
using TaskCFT.Models.Entities;
using TaskCFT.Models.ViewModels.WorkRequestVM;

namespace TaskCFT.Services
{
    public class WorkRequestService
    {
        private readonly AppDbContext _context;

        public WorkRequestService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<WorkRequestListVM>> GetListVMsAsync(int page, int pageSize)
        {
            var requsts = _context.WorkRequest.Select(x =>
            new WorkRequestListVM
            {
                Id = x.Id,
                Name = x.Name,
                EndDate = x.EndDate,
                Email = x.Email,
                ApplicationName = x.Application.Name
            });

            return await PaginatedList<WorkRequestListVM>.CreateAsync(requsts.AsNoTracking(), page, pageSize);
        }

        public int GetTolalCount()
        {
            return _context.WorkRequest.Count();
        }

        public async Task<WorkRequestDetailVM> GetDetailVMAsync(int id)
        {
            var workRequest = await _context.WorkRequest
                .Include(x => x.Application)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workRequest == null)
            {
                throw new Exception($"Ошибка выполненния. Элемент с id={id} не найден");
            }
            return new WorkRequestDetailVM 
            { 
                Id = workRequest.Id, 
                ApplicationName = workRequest.Application.Name,
                Name = workRequest.Name,
                Description = workRequest.Description,
                Email = workRequest.Email,
                EndDate = workRequest.EndDate
            };
        }

        public SelectList /*WorkRequestDataVM*/ GetSelectedList()
        {
            //return new WorkRequestDataVM
            //{
            //    ApplicationsList = new SelectList(_context.Application, "Id", "Name")
            //};

            return new SelectList(_context.Application, "Id", "Name");
        }

        public async Task<bool> CreateAsync(WorkRequestDataVM workRequest)
        {

            var app = await _context.Application.FirstOrDefaultAsync(x => x.Id == workRequest.ApplicationId);
            if (app == null)
            {
                return false;
            }

            var request = new WorkRequest
            {
                Name = workRequest.Name,
                Description = workRequest.Description,
                Email = workRequest.Email,
                EndDate = workRequest.EndDate.Date,
                ApplicationId = workRequest.ApplicationId,
                Application = app
            };

            _context.Add(request);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<WorkRequestDataVM> GetDataVMAsync(int id)
        {
            var request = await _context.WorkRequest.FindAsync(id);

            if (request == null)
            {
                throw new Exception($"Ошибка выполненния. Элемент с id={id} не найден");
            }

            var app = await _context.Application.FindAsync(request.ApplicationId);

            if (request == null)
            {
                throw new Exception($"Ошибка выполненния. Элемент с id={request.ApplicationId} не найден");
            }

            return new WorkRequestDataVM
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Email = request.Email,
                EndDate = request.EndDate.Date,
                Application = app,
                ApplicationId = request.ApplicationId,
                ApplicationsList = GetSelectedList()
            };
        }

        public async Task<WorkRequestDataVM> GetDataToReturn(WorkRequestDataVM workRequest)
        {
            var app = await _context.Application.FindAsync(workRequest.ApplicationId);

            if (app == null)
                throw new Exception($"Ошибка выполненния. Элемент с id={workRequest.ApplicationId} не найден");

            workRequest.ApplicationsList = GetSelectedList();
            workRequest.Application = app;

            return workRequest;
        }

        public async Task<bool> EditAsync(WorkRequestDataVM workRequest)
        {
            var app = await _context.Application.FindAsync(workRequest.ApplicationId);
            if (app == null)
            {
                return false;
            }

            var request = new WorkRequest
            {
                Id = workRequest.Id,
                Name = workRequest.Name,
                Email = workRequest.Email,
                EndDate = workRequest.EndDate.Date,
                Application = app,
                ApplicationId = workRequest.ApplicationId,
                Description = workRequest.Description
            };

            try
            {
                _context.Update(request);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkRequestExists(request.Id))
                {
                    return false;
                }
                else
                {
                    throw new DbUpdateException();
                }
            }

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var workRequest = await _context.WorkRequest.FindAsync(id);
            if (workRequest != null)
            {
                _context.WorkRequest.Remove(workRequest);
            }

            await _context.SaveChangesAsync();
        }

        private bool WorkRequestExists(int id)
        {
            return _context.WorkRequest.Any(e => e.Id == id);
        }
    }
}
