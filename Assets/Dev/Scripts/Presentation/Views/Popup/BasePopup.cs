using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.Scripts.Presentation.Views.Popup
{
    public abstract class BasePopup : MonoBehaviour
    {
        [SerializeField] private float animationDuration = 0.3f;
        [SerializeField] [Range(0f, 1f)] private float darkTransparency;
        [SerializeField] private Image darkBackground;
        [SerializeField] private GameObject content;

        private void Awake()
        {
            content.transform.localScale = Vector3.zero;
            SetDarkBackgroundAlpha(0f);
            gameObject.SetActive(false);
        }

        protected virtual void Open()
        {
            content.transform.localScale = Vector3.zero;
            SetDarkBackgroundAlpha(0f);

            gameObject.SetActive(true);
            content.transform.DOScale(1f, animationDuration).SetEase(Ease.OutBack);
            darkBackground.DOFade(darkTransparency, animationDuration).SetEase(Ease.InSine)
                .OnComplete(() => SetDarkBackgroundAlpha(darkTransparency));
        }

        protected virtual void Close()
        {
            content.transform.DOScale(0f, animationDuration).SetEase(Ease.OutBack)
                .OnComplete(() => gameObject.SetActive(false));
            darkBackground.DOFade(0f, animationDuration).SetEase(Ease.InSine)
                .OnComplete(() => SetDarkBackgroundAlpha(0f));
        }

        private void SetDarkBackgroundAlpha(float alpha)
        {
            var color = darkBackground.color;
            color.a = alpha;
            darkBackground.color = color;
        }
    }
}