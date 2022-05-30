using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Controllers.Models
{
    public class SportsBuddyErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
       
    }
}
