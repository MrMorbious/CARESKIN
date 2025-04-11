using Microsoft.EntityFrameworkCore;
using SWP391_CareSkin_BE.Data;
using SWP391_CareSkin_BE.Models;
using SWP391_CareSkin_BE.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP391_CareSkin_BE.Repositories.Implementations
{
    public class RatingFeedbackRepository : IRatingFeedbackRepository
    {
        private readonly MyDbContext _context;

        public RatingFeedbackRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RatingFeedback>> GetAllRatingFeedbacksAsync()
        {
            return await _context.RatingFeedbacks
                .Include(rf => rf.Customer)
                .Include(rf => rf.Product)
                .Include(rf => rf.RatingFeedbackImages)
                .OrderByDescending(rf => rf.RatingFeedbackId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingFeedback>> GetActiveRatingFeedbacksAsync()
        {
            return await _context.RatingFeedbacks
                .Include(rf => rf.Customer)
                .Include(rf => rf.Product)
                .Include(rf => rf.RatingFeedbackImages)
                .Where(rf => rf.IsActive)
                .OrderByDescending(rf => rf.RatingFeedbackId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingFeedback>> GetInactiveRatingFeedbacksAsync()
        {
            return await _context.RatingFeedbacks
                .Include(rf => rf.Customer)
                .Include(rf => rf.Product)
                .Include(rf => rf.RatingFeedbackImages)
                .Where(rf => !rf.IsActive)
                .OrderByDescending(rf => rf.RatingFeedbackId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingFeedback>> GetRatingFeedbacksByProductIdAsync(int productId)
        {
            return await _context.RatingFeedbacks
                .Include(rf => rf.Customer)
                .Include(rf => rf.Product)
                .Include(rf => rf.RatingFeedbackImages)
                .Where(rf => rf.ProductId == productId)
                .OrderByDescending(rf => rf.RatingFeedbackId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingFeedback>> GetRatingFeedbacksByCustomerIdAsync(int customerId)
        {
            return await _context.RatingFeedbacks
                .Include(rf => rf.Product)
                .Include(rf => rf.RatingFeedbackImages)
                .Where(rf => rf.CustomerId == customerId)
                .OrderByDescending(rf => rf.RatingFeedbackId)
                .ToListAsync();
        }

        public async Task<RatingFeedback> GetRatingFeedbackByIdAsync(int id)
        {
            return await _context.RatingFeedbacks
                .Include(rf => rf.Customer)
                .Include(rf => rf.Product)
                .Include(rf => rf.RatingFeedbackImages)
                .FirstOrDefaultAsync(rf => rf.RatingFeedbackId == id);
        }

        public async Task<RatingFeedback> CreateRatingFeedbackAsync(RatingFeedback ratingFeedback)
        {
            _context.RatingFeedbacks.Add(ratingFeedback);
            await _context.SaveChangesAsync();
            return ratingFeedback;
        }

        public async Task<RatingFeedback> UpdateRatingFeedbackAsync(RatingFeedback ratingFeedback)
        {
            _context.Entry(ratingFeedback).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ratingFeedback;
        }

        public async Task<double> GetAverageRatingForProductAsync(int productId)
        {
            // Only consider active ratings
            var activeRatings = await _context.RatingFeedbacks
                .Where(rf => rf.ProductId == productId && rf.IsActive)
                .Select(rf => rf.Rating)
                .ToListAsync();

            // If there are no active ratings, return 0
            if (activeRatings == null || !activeRatings.Any())
                return 0;

            // Calculate the average with proper rounding to 1 decimal place
            double averageRating = activeRatings.Average();
            return Math.Round(averageRating, 1);
        }
    }
}
