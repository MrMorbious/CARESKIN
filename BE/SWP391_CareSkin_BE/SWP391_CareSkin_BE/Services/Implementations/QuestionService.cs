using SWP391_CareSkin_BE.DTOS.Requests.Question;
using SWP391_CareSkin_BE.DTOS.Responses.Question;
using SWP391_CareSkin_BE.DTOs.Responses.Question;
using SWP391_CareSkin_BE.Mappers;
using SWP391_CareSkin_BE.Models;
using SWP391_CareSkin_BE.Repositories.Interfaces;
using SWP391_CareSkin_BE.Services.Interfaces;
using System.Threading.Tasks;

namespace SWP391_CareSkin_BE.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizRepository _quizRepository;

        public QuestionService(IQuestionRepository questionRepository, IQuizRepository quizRepository)
        {
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
        }

        public async Task<List<QuestionDTO>> GetQuestionsByQuizAsync(int quizId)
        {
            var quizExists = await _quizRepository.ExistsAsync(quizId);
            if (!quizExists)
            {
                throw new ArgumentException($"Quiz with ID {quizId} not found");
            }

            var questions = await _questionRepository.GetByQuizIdAsync(quizId);
            return QuestionMapper.ToDTOList(questions);
        }

        public async Task<QuestionDetailsDTO> GetQAByQuizAsync(int questionId, bool includeAnswers)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            if (question == null)
            {
                throw new ArgumentException($"Question with ID {questionId} not found");
            }

            return QuestionMapper.ToDetailsDTO(question, includeAnswers);
        }

        public async Task<QuestionDTO> GetQuestionByIdAsync(int questionId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            if (question == null)
            {
                throw new ArgumentException($"Question with ID {questionId} not found");
            }

            return QuestionMapper.ToDTO(question);
        }

        public async Task<QuestionDTO> CreateQuestionAsync(int quizId, CreateQuestionDTO createQuestionDTO)
        {
            var quizExists = await _quizRepository.ExistsAsync(quizId);
            if (!quizExists)
            {
                throw new ArgumentException($"Quiz with ID {quizId} not found");
            }

            var question = QuestionMapper.ToEntity(quizId, createQuestionDTO);
            var createdQuestion = await _questionRepository.CreateAsync(question);

            return QuestionMapper.ToDTO(createdQuestion);
        }

        public async Task<QuestionDTO> UpdateQuestionAsync(int questionId, UpdateQuestionDTO updateQuestionDTO)
        {
            var existingQuestion = await _questionRepository.GetByIdAsync(questionId);
            if (existingQuestion == null)
            {
                throw new ArgumentException($"Question with ID {questionId} not found");
            }

            QuestionMapper.UpdateEntity(existingQuestion, updateQuestionDTO);
            var updatedQuestion = await _questionRepository.UpdateAsync(existingQuestion);

            return QuestionMapper.ToDTO(updatedQuestion);
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            var exists = await _questionRepository.ExistsAsync(questionId);
            if (!exists)
            {
                throw new ArgumentException($"Question with ID {questionId} not found");
            }

            await _questionRepository.DeleteAsync(questionId);
        }
    }
}
