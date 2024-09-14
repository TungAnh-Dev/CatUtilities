using System;
using CatUtilities;
using UnityEngine;

public class AdsManager : Singleton<AdsManager>
{
    // public bool isNoAds;
    // private DateTime pauseTime;
    // private float callapTimerInGamePlay;
    // private float callapTimerNotInGame;
    // public bool canShowInterAds;
    // public bool canShowCollap = false;

    // private void Start()
    // {
    //     canShowInterAds = false;

    //     LoadFirebaseCappingTimeInter();

    //     // Debug.Log(HandleFireBase.inter_ad_first_time_delay);
    //     // Debug.Log(HandleFireBase.inter_ad_capping_time);



    //     if (PlayerPrefs.GetInt("1sst", 0) <= 1)
    //     {
    //         Invoke(nameof(LoadFirebaseCappingTimeInter), (float)FirebaseKeys.inter_ad_first_time_delay.DoubleValue);
    //     }
    //     else
    //     {
    //         Invoke(nameof(LoadFirebaseCappingTimeInter), (float)FirebaseKeys.inter_ad_capping_time.DoubleValue);
    //     }

    //     canShowCollap = FirebaseKeys.collapse_banner_on_off.BooleanValue;

    //     Invoke(nameof(ShowBanner), 5f);

    //     DontDestroyOnLoad(this.gameObject);
    // }

    // private void ShowBanner()
    // {
    //     AdBridge.Instant.ShowAd(AD_TYPE.Banner, callback: (id, state) =>
    //     {

    //         if (state == AdUnitState.None)
    //         {
    //             Debug.Log($"FailBanner");
    //         }

    //     }, isShowNoAd: true);


        
    // }

    //     //     if(AdsManager.Instant.isNoAds)
    //     // {
    //     //     FireBaseBridge.Instant.LogEventWithOneParam(FirebaseEventLogger.USER_OPEN_TENNIS);
    //     //     UIManager.Instant.OpenUI_Immediately<TennisMenuUI>();
    //     // }
    //     // else
    //     // {
    //         // AdBridge.Instant.ShowAd(AD_TYPE.Reward,callback:(id, state)=>
    //         //         {

    //         //             if(state == AdUnitState.Closed || state == AdUnitState.Interupt || state == AdUnitState.None)
    //         //             {
    //         //                 //
    //         //             }

    //         //             if(state == AdUnitState.Watched)
    //         //             {

    //         //                 Hashtable datas = new Hashtable()
    //         //                 {
    //         //                     {LevelManager.Instant.CurrentLevel.GetSectionTitle(), 1},
    //         //                 };
    //         //                 Debug.Log(LevelManager.Instant.CurrentLevel.GetSectionTitle());
    //         //                 FireBaseBridge.Instant.LogEventWithParameterAsync(FirebaseEventLogger.USER_GET_REPLAY, datas);
    //         //                 OnReplayRound.Raise();
    //         //                 Close(0f);
    //         //             }
    //         //         }, isShowNoAd:true);
    //     //}





    // private void LoadFirebaseCappingTimeInter()
    // {
    //     AdBridge.Instant.SetCappingTime(()=> (float)FirebaseKeys.inter_ad_capping_time.DoubleValue, isShowStart: true);
        
    //     //canShowInterAds = true;
    // }

    // public void ShowAOA()
    // {
    //     AdBridge.Instant.ShowAd(AD_TYPE.Aoa);
    // }

    // private void Update() 
    // {
    //     if(isNoAds) return;

    //     if(FirebaseKeys.collapse_banner_on_off.BooleanValue == true)
    //     {
    //         callapTimerInGamePlay += Time.deltaTime;
    //         callapTimerNotInGame += Time.deltaTime;

    //         if(CanShowCollap())
    //         {
    //             ShowCollapsible(true);
    //         }
    //     }

        


    // }


    

    // public void SetCanShowCollap(bool state)
    // {
    //     canShowCollap = state;
    // }

    // public bool CanShowCollap()
    // {
    //     if(!canShowCollap || isNoAds) return false;

    //     if(PlayerPrefs.GetInt("1sst",0)<= 1)
    //     {
    //         if(sectionInterAds >= FirebaseKeys.first_misson_delay.DoubleValue)
    //         {
    //             if(callapTimerInGamePlay > FirebaseKeys.collap_capping_time.DoubleValue && GameManager.Instant.IsState(GameState.GamePlay))
    //             {
    //                 return true;
    //             }
    //         }
            
    //     }
    //     else
    //     {
    //         if(callapTimerInGamePlay > FirebaseKeys.collap_capping_time.DoubleValue && GameManager.Instant.IsState(GameState.GamePlay))
    //         {
    //             return true;
    //         }
    //     }
        
    //     return false;
        
    // }

    // public bool CanShowCollapIsNotGamePlay()
    // {
    //     if(!canShowCollap || isNoAds) return false;

    //     if(PlayerPrefs.GetInt("1sst",0)<= 1)
    //     {
    //         if(sectionInterAds >= FirebaseKeys.first_misson_delay.DoubleValue)
    //         {
    //             if(callapTimerNotInGame > FirebaseKeys.colap_capping_time_after_turnoff_button.DoubleValue)
    //             {
    //                 return true;
    //             }
    //         }
            
    //     }
    //     else
    //     {
    //         if(callapTimerNotInGame > FirebaseKeys.colap_capping_time_after_turnoff_button.DoubleValue)
    //         {
    //             return true;
    //         }
    //     }
        
    //     return false;
        
    // }



    // public void ShowMREC()
    // {
    //     //Debug.Log($"MREC showed by adsManager");
    //     //AdBridge.Instant.ShowAd(AD_TYPE.MRecs, 1);
    // }

    // int tmp = 0;

    // public void ShowCollapsible(bool isInGamePlay = false)
    // {
    //     if(isNoAds) return;

    //     if(isInGamePlay)
    //     {
    //         Debug.Log($"Collap showed by adsManager in gameplay");
    //         callapTimerInGamePlay = 0;
    //     }  
    //     else
    //     {
    //         Debug.Log($"Collap showed by adsManager NOT in gameplay");
    //         callapTimerNotInGame = 0;
    //     } 
        
    //     //Debug.Log(FirebaseKeys.Id_Collap_Test.DoubleValue);
    //     AdBridge.Instant.ShowAd(AD_TYPE.MRecs, 0, isShowNoAd:true);

    //     if(tmp == 0)
    //     {
    //         AdBridge.Instant.HideAd(AD_TYPE.Banner);
    //         tmp++;
    //     }
        
    // }

    // public void ShowInterAds()
    // {
    //     if(isNoAds) return;
        
    //     AdBridge.Instant.ShowAd(AD_TYPE.Inter, isShowNoAd:true);
    // }

    // // private void Update() {
    // //     Debug.Log(CanShowInterAds());
    // // }

    // public void ShowBannerAds()
    // {
    //     AdBridge.Instant.ShowAd(AD_TYPE.Banner);
    // }

    // public int sectionInterAds;

    // public bool CanShowInterAds()
    // {
    //     if(isNoAds) return false;

    //     if(PlayerPrefs.GetInt("1sst",0)<= 1)
    //     {
    //         return sectionInterAds >= FirebaseKeys.first_misson_delay.DoubleValue;
    //     }

    //     return true;
    // }

    // void OnApplicationPause(bool pauseStatus)
    // {
    //     if (pauseStatus)
    //     {
    //         pauseTime = DateTime.Now;
    //         Debug.Log("Ứng dụng đã bị tạm dừng");
            
            
    //     }
    //     else
    //     {
    //         TimeSpan timeDiff = DateTime.Now - pauseTime;
    //         if (timeDiff.TotalSeconds > (float)FirebaseKeys.open_ad_capping_time.DoubleValue)
    //         {
    //             Debug.Log($"Đã vào lại sau {(float)FirebaseKeys.open_ad_capping_time.DoubleValue} giây");
    //             ShowAOA();
    //         } 
    //         else
    //         {
    //             Debug.Log($"Thoát ứng dụng được {timeDiff.TotalSeconds} giây");
    //         }
    //     }
    // }


}