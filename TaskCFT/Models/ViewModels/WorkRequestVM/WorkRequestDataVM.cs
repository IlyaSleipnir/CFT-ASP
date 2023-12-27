using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TaskCFT.Models.Entities;

namespace TaskCFT.Models.ViewModels.WorkRequestVM
{
    public class WorkRequestDataVM
    {
        public int Id { get; set; }

        [Display(Name ="Название")]
        [Required(ErrorMessage = "Требуется ввести название")]
        [MinLength(2, ErrorMessage = "Название должно содержать хотя бы 2 символа")]
        [MaxLength(50, ErrorMessage = "Название не должно быть длиннее 50 символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Дата окончания разработки")]
        [Required(ErrorMessage = "Требуется выбрать дату окончания")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Ваш Email")]
        [Required(ErrorMessage = "Требуется ввести электронную почту")]
        [EmailAddress(ErrorMessage = "Несоответсвие формата адресу электронной почте")]
        public string Email { get; set; }

        public Application? Application { get; set; }

        [Display(Name = "Приложение")]
        [Required(ErrorMessage = "Требуется выбрать приложение")]
        [Range(0, int.MaxValue, ErrorMessage = "Требуется выбрать приложение")]
        public int ApplicationId { get; set; }

        public SelectList? ApplicationsList { get; set; }

    }
}
