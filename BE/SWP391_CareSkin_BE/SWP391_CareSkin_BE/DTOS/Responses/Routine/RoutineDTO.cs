﻿namespace SWP391_CareSkin_BE.DTOS.Responses.Routine
{
    public class RoutineDTO
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; }
        public string RoutinePeriod { get; set; }
        public string Description { get; set; }
        public int SkinTypeId { get; set; }
        public string SkinTypeName { get; set; }

        public bool IsActive { get; set; }

        // Danh sách các Step của Routine
        public List<RoutineStepDTO> RoutineStepDTOs { get; set; } = new List<RoutineStepDTO>();

        // Danh sách các Product liên kết trong Routine
        public List<RoutineProductDTO> RoutineProducts { get; set; } = new List<RoutineProductDTO>();
    }
}
