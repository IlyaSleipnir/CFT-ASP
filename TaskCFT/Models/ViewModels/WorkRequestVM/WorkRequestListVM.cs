using System.ComponentModel.DataAnnotations;
using TaskCFT.Models.Entities;

namespace TaskCFT.Models.ViewModels.WorkRequestVM
{
    public class WorkRequestListVM
    {

        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Дата окончания разработки")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Display(Name = "Название приложения")]
        public string ApplicationName { get; set; }

    }
}
