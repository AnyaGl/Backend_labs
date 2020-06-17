using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class CreateCommentDTO
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите текст комментария")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Отсутствует id велосипеда")]
        public int BikeId { get; set; }
    }
}
