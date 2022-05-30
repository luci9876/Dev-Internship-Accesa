using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IChallengeRepository
    {
        IEnumerable<Challenge> GetChallenges();

        Challenge GetChallengeByID(int id);

        Challenge AddChallenge(Challenge challenge);

        Challenge RemoveChallenge(Challenge challenge);

        Challenge UpdateChallenge(Challenge challenge);

        IEnumerable<Challenge> GetChallengeByAuthor(int authorId);
    }
}