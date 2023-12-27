using System.ComponentModel.DataAnnotations;

namespace TaskCFT.Models.ViewModels.ApplicationVM
{
    public class ApplicationListVM
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
