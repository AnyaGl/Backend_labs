using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        void CreateComment(CreateCommentDTO comment);
        List<CommentResultDTO> GetCommentsByBikeId(int bikeId);
    }
}
