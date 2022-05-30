using Accesa.SportsBuddy.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public decimal? Rating { get; set; }
        public string Comment { get; set; }
        public int TraineeId { get; set; }
        public string TraineeFirstName { get; set; }
        public string TraineeLastName { get; set; }
        public int TrainingId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
