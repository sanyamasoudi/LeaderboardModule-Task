using System;
using Cysharp.Threading.Tasks;
using Dev.Scripts.Data.Repository;
using Dev.Scripts.Presentation.Views;
using UnityEngine;

namespace Dev.Scripts.Presentation.Presenter
{
    public class LeaderboardPresenter
    {
        private readonly LeaderboardView _view;
        private readonly ILeaderboardRepository _repository;

        public LeaderboardPresenter(LeaderboardView view, ILeaderboardRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        public async UniTask LoadAsync()
        {
            _view.ShowLoading(true);
            try
            {
                var models = await _repository.GetLeaderboardAsync();
                _view.ShowLoading(false);
                _view.ShowUsers(models);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                _view.ShowLoading(false);
                _view.ShowError(e.Message);
            }
        }
    }
}