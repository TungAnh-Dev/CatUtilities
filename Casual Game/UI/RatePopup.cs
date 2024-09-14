using System.Collections.Generic;
using Cysharp.Threading.Tasks;
//using DVAH;
using UnityEngine;
using UnityEngine.UI;

public class RatePopup : UICanvas
{
    // public List<ButtonBase> rateButtons; // Danh sách nút xếp hạng
    // public ButtonBase laterBtn;
    // public ButtonBase yesBtn;
    // private int playerRate = 1;
    // public Sprite starActiveSpt;
    // public Sprite starDeActiveSpt;
    // bool isRated;
    // public const string Rated = "Rated";

    // void Start()
    // {
    //     isRated = false;
    //     AdsManager.Instant.ShowMREC();
    // }

    // void OnEnable()
    // {
    //     laterBtn.interactable = true;
    //     yesBtn.interactable = true;

    //     playerRate = 1;

    //     yesBtn.onClick.AddListener(OnYes);
    //     laterBtn.onClick.AddListener(OnCloseBtn);

    //     foreach (ButtonBase rateButton in rateButtons)
    //     {
    //         rateButton.onClick.AddListener(() => OnRateBtn(rateButtons.IndexOf(rateButton) + 1));
    //     }
    // }
    
    // void OnDisable()
    // {
    //     yesBtn.onClick.RemoveListener(OnYes);
    //     laterBtn.onClick.RemoveListener(OnCloseBtn);

    //     foreach (ButtonBase rateButton in rateButtons)
    //     {
    //         rateButton.onClick.RemoveAllListeners();
    //     }
    // }



    // public void OnCloseBtn()
    // {
    //     PlayerPrefs.SetInt(Rated, 1);
    //     laterBtn.interactable = false;
    //     FireBaseBridge.Instant.LogEventWithOneParam(FirebaseEventLogger.USER_RATING_CLOSE);
    //     Close(0.3f);
    // }

    // public void OnYes()
    // {
    //     PlayerPrefs.SetInt(Rated, 1);
    //     if (playerRate >= 4 || !isRated) 
    //     {
    //         yesBtn.interactable = false;
    //         Application.OpenURL($"https://play.google.com/store/apps/details?id=com.mirai.student.simulator.school");
    //         //InAppReviewMirai.OpenReview();
    //         Close(0.3f);
    //     }
    //     else
    //     {
    //         yesBtn.interactable = false;
    //         Close(0.3f);
    //     }

    //     FireBaseBridge.Instant.LogEventWithOneParam(FirebaseEventLogger.USER_RATED);
    // }

    // public void OnRateBtn(int rate)
    // {
    //     isRated = true;
    //     playerRate = rate;
    //     for (int i = 0; i < rateButtons.Count; i++)
    //     {
    //         if (i < rate)
    //             rateButtons[i].image.sprite = starActiveSpt;
    //         else
    //             rateButtons[i].image.sprite = starDeActiveSpt;
    //     }
    // }

    // public override void CloseDirectly()
    // {
    //     if(AdsManager.Instant.CanShowCollapIsNotGamePlay())
    //     {
    //         AdsManager.Instant.ShowCollapsible(false);
    //     }

    //     base.CloseDirectly();
    // }
}
