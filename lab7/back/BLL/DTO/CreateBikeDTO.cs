using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class CreateBikeDTO
    {

        [Required(ErrorMessage = "Введите название велосипеда")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите диметр колес")]
        public double Diameter { get; set; }

        [Required(ErrorMessage = "Введите стоимость велосипеда")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Введите описание велосипеда")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Выберите, для кого предназначен велосипед")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Введите бренд велосипеда")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Введите тип велосипеда")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Не удалось получить изображение")]
        public IFormFile File { get; set; }
    }
}
