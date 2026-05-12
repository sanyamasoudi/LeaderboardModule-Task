using System.Collections.Generic;
using Dev.Scripts.Domain;
using Dev.Scripts.Presentation.Presenter;
using Dev.Scripts.Presentation.Views.Popup;
using UnityEngine;

namespace Dev.Scripts.Presentation.Views
{
    [RequireComponent(typeof(LeaderboardItemPool))]
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private GameObject loading;

        private LeaderboardItemPool _leaderboardItemPool;
        private LeaderboardPresenter _leaderboardPresenter;
        private ErrorMessagePopup _errorMessagePopup;

        private void Awake()
        {
            _leaderboardItemPool = GetComponent<LeaderboardItemPool>();
        }

        private async void Start()
        {
            await _leaderboardPresenter.LoadAsync();
        }

        public void Setup(LeaderboardPresenter leaderboardPresenter, ErrorMessagePopup messagePopup)
        {
            _leaderboardPresenter = leaderboardPresenter;
            _errorMessagePopup = messagePopup;
        }

        public void ShowUsers(List<LeaderboardUserModel> models)
        {
            foreach (var model in models)
            {
                var item = _leaderboardItemPool.Pool.Get();
                item.Bind(model);
            }
        }

        public void ShowError(string message)
        {
            _errorMessagePopup.ShowErrorMessage(message);
        }

        public void ShowLoading(bool show)
        {
            loading.SetActive(show);
        }
    }
}