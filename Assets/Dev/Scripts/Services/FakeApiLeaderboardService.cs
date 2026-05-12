using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Dev.Scripts.Data.Configs;
using Dev.Scripts.Data.DTO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Dev.Scripts.Services
{
    public class FakeApiLeaderboardService : ILeaderboardService
    {
        private readonly ApiConfig _apiConfig;
        public FakeApiLeaderboardService(ApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public async UniTask<List<LeaderboardUserDto>> GetLeaderboardUsersAsync()
        {
            var leaderboardUsers = new List<LeaderboardUserDto>();

            using var webRequest = UnityWebRequest.Get(_apiConfig.ApiBaseUrl);
            webRequest.timeout = _apiConfig.RequestTimeoutSeconds;
            
            Debug.Log("Start sending Request");
            await webRequest.SendWebRequest();
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                leaderboardUsers = Deserialize(webRequest.downloadHandler.text);
            }

            await UniTask.Delay(TimeSpan.FromSeconds(_apiConfig.SimulatedResponseDelaySeconds));
            return leaderboardUsers;

        }

        private List<LeaderboardUserDto> Deserialize(string json)
        {
            var userDtos = JsonConvert.DeserializeObject<List<LeaderboardUserDto>>(json);
            return userDtos;
        }
    }
}