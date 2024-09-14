using System.Collections;
//using DVAH;
using ScriptableObjectArchitecture;
using UnityEngine;

public class ReplayPopup : UICanvas
{
    [SerializeField] ButtonBase replayBtn;
    [SerializeField] ButtonBase nothankBtn;
    //[SerializeField] ButtonBase replayFreeBtn;
    public GameEvent OnReplayRound;
    //public const string Free_Replay = "2 time free";

    bool isScale = false;

    void OnEnable()
    {
        replayBtn.onClick.AddListener(ReplayButton);
        nothankBtn.onClick.AddListener(CloseButton);
        //replayFreeBtn.onClick.AddListener(ReplayFreeBtn);
    }
    
    void OnDisable()
    {
        replayBtn.onClick.RemoveListener(ReplayButton);
        nothankBtn.onClick.RemoveListener(CloseButton);
        //replayFreeBtn.onClick.RemoveListener(ReplayFreeBtn);
    }

    public override void Open()
    {
        base.Open();

        // if(UserData.Ins.level < 1 || (UserData.Ins.level == 1 && UserData.Ins.round == 0))
        // {
        //     CloseButton();
        //     isScale = false;
        // }
        // else
        // {
        //     isScale = true;
        // }


        nothankBtn.SetActive(false);

        
        VibrationController.Instant.PlayVibrate(CameraShakeType.moderate);

        replayBtn.SetActive(true);



        Invoke(nameof(ActiveNothankBtn), 2f);



        // if(PlayerPrefs.GetInt(Free_Replay) < 2)
        // {
        //     replayBtn.SetActive(false);
        //     replayFreeBtn.SetActive(true);
        // }
        // else
        // {
        //     replayBtn.SetActive(true);
        //     replayFreeBtn.SetActive(false);
        // }


        

        //AdsManager.Instant.ShowMREC();
        
    }

    private void ActiveNothankBtn() => nothankBtn.SetActive(true);


    // private void ReplayFreeBtn()
    // {
    //     int tmp = PlayerPrefs.GetInt(Free_Replay,0)+1;

    //     //Debug.Log($"{tmp}");

    //     PlayerPrefs.SetInt(Free_Replay,tmp);
    //     OnReplayRound.Raise();
    //     Close(0f);
    // }

    private void CloseBtnWithScale()
    {
        if(isScale)
        {
            Close(0.3f);
        }
        else
        {
            Close(0f);
        }
    }

    private void ReplayButton()
    {
        //Debug.Log($"LOLOLOLO");
        // if(AdsManager.Instant.isNoAds)
        // {
        //     OnReplayRound.Raise();
        //     CloseBtnWithScale();
        // }
        // else
        // {
        //     AdBridge.Instant.ShowAd(AD_TYPE.Reward,callback:(id, state)=>
        //     {

        //         if(state == AdUnitState.Closed || state == AdUnitState.Interupt || state == AdUnitState.None)
        //         {
        //             //
        //         }

        //         if(state == AdUnitState.Watched)
        //         {

        //             Hashtable datas = new Hashtable()
        //             {
        //                 {LevelManager.Instant.CurrentLevel.GetSectionTitle(), 1},
        //             };
        //             Debug.Log(LevelManager.Instant.CurrentLevel.GetSectionTitle());
        //             FireBaseBridge.Instant.LogEventWithParameterAsync(FirebaseEventLogger.USER_GET_REPLAY, datas);
        //             OnReplayRound.Raise();
        //             Close(0f);
        //         }
        //     }, isShowNoAd:true, placement: "Replay_button");
        // }

        
        

        
        // GameManager.Ins.ChangeState(GameState.GamePlay);
        // 
        // LevelManager.Ins.OnRevive();
        // UIManager.Ins.OpenUI<UIGameplay>();
    }

    public override void CloseDirectly()
    {
        // if(AdsManager.Instant.CanShowCollapIsNotGamePlay())
        // {
        //     AdsManager.Instant.ShowCollapsible(false);
        // }

        // base.CloseDirectly();
    }

    private void CloseButton()
    {
        // if(AdsManager.Instant.CanShowInterAds() && FirebaseKeys.inter_replay_scene_on_off.BooleanValue == true)
        // {
        //     AdBridge.Instant.ShowAd(AD_TYPE.Inter,callback:(id, state)=>
        //     {

        //         if(state == AdUnitState.Closed || state == AdUnitState.Interupt || state == AdUnitState.None || state == AdUnitState.Watched) 
        //         {
        //             //Debug.Log($"Inter Closed");
        //             CloseBtnWithScale();
        //         }
        //     }, isShowNoAd:true);
        // }
        // else
        // {
        //     CloseBtnWithScale();
        // }

        

        
        
    }



}