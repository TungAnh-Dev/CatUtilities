using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData", order = 1)]
public class UserData : ScriptableObject
{
    private static UserData ins;
    public static UserData Ins
    {
        get
        {
            if (ins == null)
            {
                UserData datas = Resources.Load<UserData>("UserData");

                if (datas == null) 
                {
                    Debug.LogError("have multiple Scriptableobject UserData");
                }else ins = datas;

                //Debug.LogError("found userdata");
            }
            
            return ins;
        }
    }

    public const string Key_Round = "Round";
    public const string Key_Level = "Level";
    public const string Key_Money = "Money";
    public const string Key_Previous_Performance = "PreviousPerformance";
    public const string Key_Previous_Behavior  = "PreviousBehavior";
    public const string Key_Performance = "Performance";
    public const string Key_Behavior  = "Behavior";
    public const string Key_MusicIsOn = "MusicIsOn";
    public const string Key_SoundIsOn = "SoundIsOn";
    public const string Key_Vibrate = "VibrateIsOn";
    public const string Key_RemoveAds = "RemoveAds";
    public const string Key_Tutorial = "Tutorial";
    public const string Key_CharacterSelection = "CharacterSelection";

    // public const string Key_Player_Weapon = "PlayerWeapon";
    // public const string Key_Player_Hat = "PlayerHat";
    // public const string Key_Player_Pant = "PlayerPant";
    // public const string Key_Player_Accessory = "PlayerAccessory";
    public const string Key_Player_Skin = "PlayerSkin";

    // public const string Keys_Weapon_Data = "WeaponDatas";
    // public const string Keys_Hat_Data = "HatDatas";
    // public const string Keys_Pant_Data = "PantDatas";
    // public const string Keys_Accessory_Data = "AccessoryDatas";
    // public const string Keys_Skin_Data = "SkinDatas";
    public const string Key_First_Open_App = "FirstOpenApp";
    public const string GUITAR_COMPLETED = "guitarCompleted";
    public const string HIGH_SCORE_GUITAR = "HIGH_SCORE_GUITAR";
    public const string CURRENT_SCORE_GUITAR = "CURRENT_SCORE_GUITAR";
    public const string TENNIS_CURRENT_TOURNAMENT = "TENNIS_CURRENT_TOURNAMENT";
    public const string CURRENT__TENNIS_BALL_ID_SELECTED = "CURRENT__TENNIS_BALL_ID_SELECTED";

    public const string HIGH_SCORE_SOCCER = "HIGH_SCORE_SOCCER";
    public const string CURRENT_SCORE_SOCCER = "CURRENT_SCORE_SOCCER";
    public const string CURRENT__SOCCER_BALL_ID_SELECTED = "CURRENT__SOCCER_BALL_ID_SELECTED";

    public const string HIGH_SCORE_BASKETBALL = "HIGH_SCORE_BASKETBALL";
    public const string CURRENT_SCORE_BASKETBALL = "CURRENT_SCORE_BASKETBALL";
    public const string CURRENT__BASKETBALL_BALL_ID_SELECTED = "CURRENT__BASKETBALL_BALL_ID_SELECTED";

    public const string BOWLING_CURRENT_TOURNAMENT = "BOWLING_CURRENT_TOURNAMENT";
    public const string CURRENT__BOWLING_BALL_ID_SELECTED = "CURRENT__BOWLING_BALL_ID_SELECTED";

    
    public const string HIGH_SCORE_WHACHAMOLE = "HIGH_SCORE_WHACHAMOLE";
    public const string CURRENT_SCORE_WHACHAMOLE = "CURRENT_SCORE_WHACHAMOLE";
    public const string CURRENT__WHACHAMOLE_ID_SELECTED = "CURRENT__WHACHAMOLE_ID_SELECTED";

    public int round = 0;
    public int level = 0;
    public int money = 0;
    public int performance = 50; 
    public int behavior = 50;
    public int previousPerformance; 
    public int previousBehavior;

    public bool musicIson = true;
    public bool soundIsOn = true;
    public bool vibrate = true;
    public bool removeAds = false;
    public bool tutorialed = false;
    public bool characterSelection = true;
    public bool fisrtOpenApp = true;



    

    //Example
    // UserData.Ins.SetInt(UserData.Key_Level, ref UserData.Ins.level, 1);

    //data for list
    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public void SetDataState(string key, int ID, int state)
    {
        PlayerPrefs.SetInt(key + ID, state);
    }
    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public int GetDataState(string key, int ID, int state = 0)
    {
        return PlayerPrefs.GetInt(key + ID, state);
    }

    public void SetDataState(string key, int state)
    {
        PlayerPrefs.SetInt(key, state);
    }

    public int GetDataState(string key, int state = 0)
    {
        return PlayerPrefs.GetInt(key, state);
    }

    /// <summary>
    /// Key_Name
    /// if(bool) true == 1
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetIntData(string key, ref int variable, int value)
    {
        variable = value;
        PlayerPrefs.SetInt(key, value);
    } 
    
    public void SetBoolData(string key, ref bool variable, bool value)
    {
        variable = value;
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public void SetFloatData(string key, ref float variable, float value)
    {
        variable = value;
        PlayerPrefs.GetFloat(key, value);
    }

    public void SetStringData(string key, ref string variable, string value)
    {
        variable = value;
        PlayerPrefs.SetString(key, value);
    }

    public void SetEnumData<T>(string key, ref T variable, T value)
    {
        variable = value;
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }

    public void SetEnumData<T>(string key,T value)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }

    public T GetEnumData<T>(string key, T defaultValue) where T : Enum
    {
        return (T)Enum.ToObject(typeof(T), PlayerPrefs.GetInt(key, Convert.ToInt32(defaultValue)));
    }


#if UNITY_EDITOR
    [Space(10)]
    [Header("---- Editor ----")]
    public bool isTest;
#endif

    public void OnInitData()
    {

#if UNITY_EDITOR
        if (isTest) return;
#endif
        round = PlayerPrefs.GetInt(Key_Round, 0);
        level = PlayerPrefs.GetInt(Key_Level, 0);
        money = PlayerPrefs.GetInt(Key_Money, 0);
        performance = PlayerPrefs.GetInt(Key_Performance, 50);
        behavior = PlayerPrefs.GetInt(Key_Behavior, 50);
        previousPerformance = PlayerPrefs.GetInt(Key_Previous_Performance, performance);
        previousBehavior = PlayerPrefs.GetInt(Key_Previous_Behavior, behavior);

        removeAds = PlayerPrefs.GetInt(Key_RemoveAds, 0) == 1;
        //tutorialed =  PlayerPrefs.GetInt(Key_Tutorial, 0) == 1;
        soundIsOn =  PlayerPrefs.GetInt(Key_SoundIsOn, 1) == 1;
        vibrate =  PlayerPrefs.GetInt(Key_Vibrate, 1) == 1;
        musicIson = PlayerPrefs.GetInt(Key_MusicIsOn, 1) == 1;
        fisrtOpenApp = PlayerPrefs.GetInt(Key_First_Open_App, 1) == 1;
        
        characterSelection = PlayerPrefs.GetInt(Key_CharacterSelection, 1) == 1;

       
        // playerWeapon = GetEnumData(Key_Player_Weapon, WeaponType.W_Hammer_1);
        // playerHat = GetEnumData(Key_Player_Hat, HatType.HAT_Arrow);
        // playerPant = GetEnumData(Key_Player_Pant, PantType.Pant_1);
        // playerAccessory = GetEnumData(Key_Player_Accessory, AccessoryType.ACC_None);

    }

    public void OnResetData()
    {
        PlayerPrefs.DeleteAll();
        OnInitData();
    }

}



#if UNITY_EDITOR

[CustomEditor(typeof(UserData))]
public class UserDataEditor : Editor
{
    UserData userData;

    private void OnEnable()
    {
        userData = (UserData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Load Data"))
        {
            userData.OnInitData();
            EditorUtility.SetDirty(userData);
        }
       
    }
}

#endif