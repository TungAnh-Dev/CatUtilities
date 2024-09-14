
using Cinemachine;
using CatUtilities;

public class CameraShakeController : Singleton<CameraShakeController>
{
    public CinemachineImpulseSource impulseSourceVerySlight;
    public CinemachineImpulseSource impulseSourceSlight;
    public CinemachineImpulseSource impulseSourceModerate;
    public CinemachineImpulseSource impulseSourceHeavy;
    // private float m_lastShakeTime;
    // public float minimumTimeBetweenShake = 0.2f;
    //public PlayModeVariable currentPlayMode;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(this.gameObject);
    }
    public void ShakeVerySlightly()
    {
        //if(Time.time-m_lastShakeTime<minimumTimeBetweenShake)
        //{
        //    return;
        //}
        //m_lastShakeTime = Time.time;
        impulseSourceVerySlight.GenerateImpulse();
    }
    public void ShakeSlightly()
    {
        //if(Time.time-m_lastShakeTime<minimumTimeBetweenShake)
        //{
        //    return;
        //}
        //m_lastShakeTime = Time.time;
        impulseSourceSlight.GenerateImpulse();
    }
    public void ShakeModerate()
    {
        //if(Time.time-m_lastShakeTime<minimumTimeBetweenShake)
        //{
        //    return;
        //}
        //m_lastShakeTime = Time.time;
        impulseSourceModerate.GenerateImpulse();
    }

    public void ShakeHeavily()
    {
        //if(Time.time-m_lastShakeTime<minimumTimeBetweenShake)
        //{
        //    return;
        //}
        //m_lastShakeTime = Time.time;
        impulseSourceHeavy.GenerateImpulse();
    }
    public void Shake(CameraShakeType type)
    {

        switch (type)
        {
            case CameraShakeType.slight:
                ShakeSlightly();
                break;

            case CameraShakeType.veryslight:
                ShakeVerySlightly();
                break;

            case CameraShakeType.moderate:
                ShakeModerate();
                break;

            case CameraShakeType.heavy:
                ShakeHeavily();
                break;

            default:
                // Optionally handle unexpected types
                break;
        }
        
    }

}

public enum CameraShakeType
{
    slight,
    moderate,
    heavy,
    veryslight
}
