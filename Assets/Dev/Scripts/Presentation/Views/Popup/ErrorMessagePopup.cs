using Dev.Scripts.Presentation.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.Scripts.Presentation.Views.Popup
{
    public class ErrorMessagePopup : BasePopup
    {
        [SerializeField] private Button retryButton;
        [SerializeField] private TextMeshProUGUI errorMessage;

        private LeaderboardPresenter _leaderboardPresenter;

        public void Setup(LeaderboardPresenter leaderboardPresenter)
        {
            _leaderboardPresenter = leaderboardPresenter;
            retryButton.onClick.AddListener(OnRetry);
        }

        public void ShowErrorMessage(string message)
        {
            errorMessage.text = message;
            Open();
        }

        private void OnRetry()
        { 
            _leaderboardPresenter.LoadAsync();
            Close();
        }
    }
}