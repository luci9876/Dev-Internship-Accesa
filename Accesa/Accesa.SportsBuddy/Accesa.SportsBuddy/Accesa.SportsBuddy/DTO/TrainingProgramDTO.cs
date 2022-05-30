using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public class TrainingProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public string RecommendedSteps { get; set; }
        public string Duration { get; set; }
        public string Location { get; set; }
        public int? SportCenterId { get; set; }
        public decimal Rating { get; set; }
        public SportCenterDTO SportCenter { get; set; }
    }
}