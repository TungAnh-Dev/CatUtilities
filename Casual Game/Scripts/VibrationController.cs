
using UnityEngine;
using Lofelt.NiceVibrations;
using CatUtilities;
public class VibrationController : Singleton<VibrationController>
{
    public HapticSource hapticSourceLight;
    public HapticSource hapticSourceMedium;
    public HapticSource hapticSourceStrong;
 
    private float m_lastVibrateTime;
    static bool isVibrated = true;
    // Start is called before the first frame update
    void Start()
    {
        HapticController.clipLevel = 0.5f;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayVibrate(CameraShakeType type)
    {
        if(!isVibrated) return;

        if (Time.time - m_lastVibrateTime <1f) return;
        m_lastVibrateTime = Time.time;
        if (type == CameraShakeType.slight)
        {
            //  instance.hapticSourceLight.Play();
            //HapticController.clipLevel = 0.5f;
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
        }
        if (type == CameraShakeType.moderate)
        {
            //HapticController.clipLevel = 0.5f;
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.MediumImpact);
        }
        if (type == CameraShakeType.heavy)
        {
            //HapticController.clipLevel = 0.5f;
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);
        }
        
    }

    public void SetVibrationEnabled(bool isVibrationOn)
    {
        if(isVibrationOn)
        {
            isVibrated = true;
        }
        else
        {
            isVibrated = false;
        }
    }
}
 