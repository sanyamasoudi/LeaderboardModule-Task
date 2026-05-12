using UnityEngine;

namespace Dev.Scripts.Data.Configs
{
    [CreateAssetMenu(fileName = "ApiConfig", menuName = "Services/ApiConfig")]
    public class ApiConfig : ScriptableObject
    {
        [SerializeField] private string apiBaseUrl;
        [SerializeField] private int simulatedResponseDelaySeconds;
        [SerializeField] private int requestTimeoutSeconds;

        public string ApiBaseUrl => apiBaseUrl;
        public int SimulatedResponseDelaySeconds => simulatedResponseDelaySeconds;
        public int RequestTimeoutSeconds => requestTimeoutSeconds;
    }
}