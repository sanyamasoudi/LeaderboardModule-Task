using Dev.Scripts.Data.Configs;
using Dev.Scripts.Data.Repository;
using Dev.Scripts.Presentation.Presenter;
using Dev.Scripts.Presentation.Views;
using Dev.Scripts.Presentation.Views.Popup;
using Dev.Scripts.Services;
using UnityEngine;

namespace Dev.Scripts.Bootstrap
{
    public class GameInitializer : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private ApiConfig apiConfig;

        [Header("Views")]
        [SerializeField] private LeaderboardView leaderboardView;
        [SerializeField] private ErrorMessagePopup errorMessagePopup;

        private ILeaderboardRepository _leaderboardRepository;
        private ILeaderboardService _leaderboardService;
        private LeaderboardPresenter _leaderboardPresenter;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _leaderboardService = new FakeApiLeaderboardService(apiConfig);
            _leaderboardRepository = new LeaderboardRepository(_leaderboardService);
            _leaderboardPresenter = new LeaderboardPresenter(leaderboardView, _leaderboardRepository);
            errorMessagePopup.Setup(_leaderboardPresenter);
            leaderboardView.Setup(_leaderboardPresenter , errorMessagePopup);
        }
    }
}