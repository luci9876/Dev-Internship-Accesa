using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Controllers.Authentication
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Trainer = "Trainer";

        public enum RoleDirection {
            NoUpdate = 0,
            UserToTrainer = 1,
            TrainerToUser = 2
        }
    }
}