using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public class TrainerSportCenterDTO
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int SportCenterId { get; set; }
        public TrainerDTO Trainer { get; set; }
    }
}
