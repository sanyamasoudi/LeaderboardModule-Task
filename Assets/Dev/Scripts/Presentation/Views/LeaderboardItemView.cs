using Dev.Scripts.Domain;
using TMPro;
using UnityEngine;

namespace Dev.Scripts.Presentation.Views
{
    public class LeaderboardItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI rank;
        [SerializeField] private TextMeshProUGUI userName;
        [SerializeField] private TextMeshProUGUI score;

        public void Bind(LeaderboardUserModel model)
        {
            rank.text = model.Rank.ToString();
            userName.text = model.Name;
            score.text = model.Score.ToString();
        }
    }
}