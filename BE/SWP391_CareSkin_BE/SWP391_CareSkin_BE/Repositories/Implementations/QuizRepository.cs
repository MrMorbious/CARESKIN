using Microsoft.EntityFrameworkCore;
using SWP391_CareSkin_BE.Data;
using SWP391_CareSkin_BE.Models;
using SWP391_CareSkin_BE.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SWP391_CareSkin_BE.Repositories.Implementations
{
    public class QuizRepository : IQuizRepository
    {
        private readonly MyDbContext _context;

        public QuizRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizs.ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> GetActiveAsync()
        {
            return await _context.Quizs
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .Where(q => q.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> GetInactiveAsync()
        {
            return await _context.Quizs
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .Where(q => !q.IsActive)
                .ToListAsync();
        }

        public async Task<Quiz?> GetByIdAsync(int quizId)
        {
            return await _context.Quizs
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(q => q.QuizId == quizId);
            
        }

        public async Task<Quiz> CreateAsync(Quiz quiz)
        {
            _context.Quizs.Add(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz> UpdateAsync(Quiz quiz)
        {
            _context.Entry(quiz).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<bool> ExistsAsync(int quizId)
        {
            return await _context.Quizs.AnyAsync(q => q.QuizId == quizId);
        }

        public async Task<Quiz?> GetByTitleAsync(string title)
        {
            return await _context.Quizs
                .FirstOrDefaultAsync(q => q.Title.ToLower() == title.ToLower());
        }
    }
}
