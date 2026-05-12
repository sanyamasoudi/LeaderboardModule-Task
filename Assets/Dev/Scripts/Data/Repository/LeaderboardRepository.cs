using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Dev.Scripts.Domain;
using Dev.Scripts.Services;

namespace Dev.Scripts.Data.Repository
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private readonly ILeaderboardService _leaderboardService;

        public LeaderboardRepository(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        public async UniTask<List<LeaderboardUserModel>> GetLeaderboardAsync()
        {
            var leaderboardUsersDto = await _leaderboardService.GetLeaderboardUsersAsync();

            var userModels = new List<LeaderboardUserModel>();
            foreach (var leaderboardUserDto in leaderboardUsersDto)
            {
                var userData = leaderboardUserDto.userData;
                var model = new LeaderboardUserModel(userData.name, userData.score, userData.rank);
                userModels.Add(model);
            }

            Sort(userModels);

            return userModels;
        }

        private void Sort(List<LeaderboardUserModel> userModels)
        {
            userModels.Sort((i, j) => j.Score.CompareTo(i.Score));
        }
    }
}