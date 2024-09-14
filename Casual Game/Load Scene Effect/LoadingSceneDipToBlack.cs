using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneDipToBlack : UICanvas
{
    [SerializeField] CanvasGroup canvasGroup;
    private float timeDipIn = 0.5f;
    private float timeDipOUt = 0.5f;
    public float GetTimeDipIn() => timeDipIn;
    public int GetTimeDipInConvertSecond() => (int)(timeDipIn * 1000);

    public override void Open()
    {
        base.Open();

        // Start with canvasGroup.alpha set to 0
        canvasGroup.alpha = 0;



        // Create a sequence for the alpha animation
        Sequence sequence = DOTween.Sequence();
        
        // Fade alpha from 0 to 1 in 0.5 seconds
        sequence.Append(canvasGroup.DOFade(1f, timeDipIn).SetEase(Ease.Linear))
                // Then fade alpha back to 0 in 0.5 seconds
                .Append(canvasGroup.DOFade(0f, timeDipOUt).SetEase(Ease.Linear))
                // Optional: Add an OnComplete callback if you want to close directly afterward
                .OnComplete(() => CloseDirectly());
    }

    public override void CloseDirectly()
    {
        base.CloseDirectly();

        // Reset canvasGroup.alpha to 0
        canvasGroup.alpha = 0;
    }
}
