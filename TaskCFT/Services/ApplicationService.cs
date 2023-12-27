using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskCFT.Data;
using TaskCFT.Models.ViewModels.ApplicationVM;
using TaskCFT.Models.ViewModels.WorkRequestVM;

namespace TaskCFT.Services
{
    public class ApplicationService
    {
        private readonly AppDbContext _context;

        public ApplicationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<ApplicationListVM>> GetListVMsAsync(int page, int pageSize)
        {
            var applications = _context.Application.Select(x =>
            new ApplicationListVM
            {
                Id = x.Id,
                Name = x.Name,
            });

            return await PaginatedList<ApplicationListVM>.CreateAsync(applications.AsNoTracking(), page, pageSize);
        }

        public int GetTotalCount()
        {
            return _context.Application.Count();
        }

        public async Task<ApplicationDetailVM> GetDetailVMAsync(int id)
        {   
            var appDetail = await _context
                .Application
                .Include(x => x.WorkRequests)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (appDetail == null) 
            {
                throw new Exception($"Ошибка выполненния. Элемент с id={id} не найден");
            }


            return new ApplicationDetailVM 
            {
                Id = appDetail.Id, 
                Name = appDetail.Name, 
                WorkRequests = appDetail.WorkRequests.Select(x => 
                new WorkRequestListVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    EndDate = x.EndDate.Date
                }).ToList()
            };
        }


    }
}
