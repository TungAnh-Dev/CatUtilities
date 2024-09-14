
using UnityEngine;

public class SettingUI : UICanvas
{
    [Header("Music")]
    public ButtonBase musicBtn;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    [Header("Sound")]
    public ButtonBase soundBtn;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    [Header("Vibration")]
    public ButtonBase vibrationBtn;
    public Sprite vibrationOnSprite;
    public Sprite vibrationOffSprite;

    public ButtonBase exitBtn;
    private bool isMusicOn;
    private bool isSoundOn;
    private bool isVibrationOn;

    public override void Open()
    {
        base.Open();

        //AdsManager.Instant.ShowMREC();

        // Load trạng thái lựa chọn trước đó của người chơi
        isMusicOn = UserData.Ins.musicIson;
        isSoundOn = UserData.Ins.soundIsOn;
        isVibrationOn = UserData.Ins.vibrate;

        // Cập nhật giao diện dựa trên trạng thái lưu trữ
        UpdateAllUI();
    }

    void OnEnable()
    {
        musicBtn.onClick.AddListener(OnMusicBtn);
        soundBtn.onClick.AddListener(OnSoundBtn);
        vibrationBtn.onClick.AddListener(OnVibrationBtn);
        exitBtn.onClick.AddListener(OnExitBtnAsync);
    }

    void OnDisable()
    {
        musicBtn.onClick.RemoveListener(OnMusicBtn);
        soundBtn.onClick.RemoveListener(OnSoundBtn);
        vibrationBtn.onClick.RemoveListener(OnVibrationBtn);
        exitBtn.onClick.RemoveListener(OnExitBtnAsync);
    }

    public void OnExitBtnAsync()
    {
        // Lưu trạng thái của người chơi khi thoát
        SavePlayerPreferences();

        // if(AdsManager.Instant.CanShowInterAds() && FirebaseKeys.inter_setting_btn_on_off.BooleanValue == true)
        // {
        //     AdsManager.Instant.ShowInterAds();
        // }
        Close(0.3f);
    }

    private void OnMusicBtn()
    {
        isMusicOn = !isMusicOn;
        UpdateMusicUI();

        if(isMusicOn)
        {
            GameSFXManager.PlayMusicByType(MusicType.BG);
        }
        
    }

    private void OnSoundBtn()
    {
        isSoundOn = !isSoundOn;
        UpdateSoundUI();
    }

    private void OnVibrationBtn()
    {
        isVibrationOn = !isVibrationOn;
        UpdateVibrationUI();
    }

    private void UpdateAllUI()
    {
        UpdateMusicUI();
        UpdateSoundUI();
        UpdateVibrationUI();
    }

    private void UpdateMusicUI()
    {
        musicBtn.image.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
        GameSFXManager.SetMusicEnabled(isMusicOn);
        UserData.Ins.SetBoolData(UserData.Key_MusicIsOn, ref UserData.Ins.musicIson, isMusicOn);
    }

    private void UpdateSoundUI()
    {
        soundBtn.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        GameSFXManager.SetSoundEnabled(isSoundOn);
        UserData.Ins.SetBoolData(UserData.Key_SoundIsOn, ref UserData.Ins.soundIsOn, isSoundOn);
    }

    private void UpdateVibrationUI()
    {
        vibrationBtn.image.sprite = isVibrationOn ? vibrationOnSprite : vibrationOffSprite;
        VibrationController.Instant.SetVibrationEnabled(isVibrationOn);
        UserData.Ins.SetBoolData(UserData.Key_Vibrate, ref UserData.Ins.vibrate, isVibrationOn);
    }

    private void SavePlayerPreferences()
    {
        // Lưu trạng thái của người chơi vào PlayerPrefs
        
        
        
        // PlayerPrefs.SetInt(MusicPreferenceKey, isMusicOn ? 1 : 0);
        // PlayerPrefs.SetInt(SoundPreferenceKey, isSoundOn ? 1 : 0);
        // PlayerPrefs.SetInt(VibrationPreferenceKey, isVibrationOn ? 1 : 0);

        // Lưu trạng thái PlayerPrefs
        PlayerPrefs.Save();
    }

    public override void CloseDirectly()
    {
        // if(AdsManager.Instant.CanShowCollapIsNotGamePlay())
        // {
        //     AdsManager.Instant.ShowCollapsible();
        // }

        base.CloseDirectly();
    }

}
