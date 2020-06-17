using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly DBContext _context;
        public CommentService(DBContext context)
        {
            _context = context;
        }

        public void CreateComment(CreateCommentDTO comment)
        {
            var newComment = new Comment()
            {
                Name = comment.Name,
                Text = comment.Text,
                Bike = GetBikeById(comment.BikeId)
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();
        }
        private Bike GetBikeById(int bikeId)
        {
            var bike = _context.Bikes.FirstOrDefault(x => x.Id == bikeId);
            if (bike == null)
            {
                throw new Exception("Не удалось найти велосипед по id");
            }
            return bike;
        }
        public List<CommentResultDTO> GetCommentsByBikeId(int bikeId)
        {
            var result = new List<CommentResultDTO>();
            var comments = _context.Comments.Include(x => x.Bike).Where(x => x.Bike.Id == bikeId);
            foreach (var comment in comments)
            {
                result.Add(new CommentResultDTO()
                {
                    Id = comment.Id,
                    Name = comment.Name,
                    Text = comment.Text
                });
            }

            return result;
        }
    }
}
