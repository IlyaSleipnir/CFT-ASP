using System.ComponentModel.DataAnnotations;
using TaskCFT.Models.ViewModels.WorkRequestVM;

namespace TaskCFT.Models.ViewModels.ApplicationVM
{
    public class ApplicationDetailVM
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Список заявок")]
        public List<WorkRequestListVM> WorkRequests { get; set; } = new List<WorkRequestListVM>();
    }
}
