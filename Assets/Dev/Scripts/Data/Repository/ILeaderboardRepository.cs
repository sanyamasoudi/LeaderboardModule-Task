using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Dev.Scripts.Domain;

namespace Dev.Scripts.Data.Repository
{
    public interface ILeaderboardRepository
    {
        public UniTask<List<LeaderboardUserModel>> GetLeaderboardAsync();
    }
}