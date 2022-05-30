using Accesa.SportsBuddy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Controllers.Models
{

    public class ActivityTrainerTrainingProgramInfo
    {
        public int TrainingProgramId { get; set; }
        public string TrainingProgramName { get; set; }
        public string TrainingProgramDifficulty { get; set; }
        public string TrainingProgramDescription { get; set; }
        public string[] TrainingProgramRecommendedSteps { get; set; }
        public string TrainingProgramDuration { get; set; }
        public string TrainingProgramLocation { get; set; }
        public ActivityTrainerInfo Trainer { get; set; }
        public decimal TrainingProgramRating { get; set; }
        #nullable enable
        public SportCenterDTO? TrainingProgramSportCenter { get; set; }

    }
}
