using SWP391_CareSkin_BE.DTOs.Responses.Question;
using SWP391_CareSkin_BE.DTOS.Responses.Answer;
using SWP391_CareSkin_BE.DTOS.Responses.Question;
using System;

namespace SWP391_CareSkin_BE.DTOS.Responses.History
{
    public class HistoryDTO
    {
        public int HistoryId { get; set; }
        public int AttemmptId { get; set; }
        public List<AnswerDTO> Answer { get; set; }
    }
}
