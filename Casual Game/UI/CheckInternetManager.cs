
using CatUtilities;
using UnityEngine;

public class CheckInternetManager : Singleton<CheckInternetManager>
{
    // public static bool noInternetPopupOpen;
    // public static bool canCheckInterNet;

    // void Start()
    // {
    //     noInternetPopupOpen = false;
    //     canCheckInterNet = false;
    //     DontDestroyOnLoad(this.gameObject);
    // }
    // void Update()
    // {
    //     if(FirebaseKeys.offline_play_on_off.BooleanValue == false || GameManager.Instant.isCreativeBuild) return;

    //     if(canCheckInterNet)
    //     {
    //         UpdateInternet();
    //     }
    // }

    // void UpdateInternet()
    // {
    //     if (Application.internetReachability == NetworkReachability.NotReachable)
    //     {
    //         if(!UIManager.Instant.IsOpened<NoInternetPopup>())
    //         {
    //             if(!UIManager.Instant.IsLoaded<HomeUI>())
    //             {
    //                 UIManager.Instant.OpenUI_Immediately<HomeUI>();
    //                 UIManager.Instant.CloseUI_Directly<HomeUI>();
    //             }
    //             else
    //             {
    //                 UIManager.Instant.OpenUI_Immediately<NoInternetPopup>();
    //             }
    //         }
    //     }

        
    // }



}
