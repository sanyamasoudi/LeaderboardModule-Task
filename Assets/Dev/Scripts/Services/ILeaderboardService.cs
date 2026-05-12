using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Dev.Scripts.Data.DTO;

namespace Dev.Scripts.Services
{
    public interface ILeaderboardService
    {
        public UniTask<List<LeaderboardUserDto>> GetLeaderboardUsersAsync();
    }
}