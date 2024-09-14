using System.Collections;
using System.Collections.Generic;
using CatUtilities;
using UnityEngine;
public class GameSFXManager : Singleton<GameSFXManager>
{
    public AudioSource musicSource;
    public AudioSource alarmSource;
    public AudioSource soundSource1;
    public AudioSource soundSource2;
    public SoundConfig soundConfig;
    public MusicConfig musicConfig;
    private Dictionary<SFXType, float> lastTimePlayASound;
    //Game events to listen to

    protected override void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        base.Awake();
           
    }

    void Start() 
    {
        lastTimePlayASound = new Dictionary<SFXType, float>();
     
    }

    // public void PlayMusic()
    // {

    // }
    void PlaySFX(SFXType type,float volumeFadeMultiplier = 1, bool isLoop = false)
    {
        Sound sound = null;
        for(int i = 0; i < soundConfig.sounds.Count; i++)
        {
            if (soundConfig.sounds[i].type == type)
            {
                sound = soundConfig.sounds[i];
            }
        }
        if (sound != null)
        {
            AudioSource soundSourceToPlay=soundSource1;
            if (sound.preferedAudioSource==2)
                soundSourceToPlay = soundSource2;
            soundSourceToPlay.volume = sound.volume* volumeFadeMultiplier;

            if(isLoop)
            {
                soundSourceToPlay.loop = true;
                soundSourceToPlay.clip = sound.clip;
                soundSourceToPlay.Play();
            }
            else
            {
                soundSourceToPlay.loop = false;
                soundSourceToPlay.PlayOneShot(sound.clip);
            }
            
        }
    }
    void PlayMusic(MusicType type)
    {
        Music music = null;
        for (int i = 0; i < musicConfig.sounds.Count; i++)
        {
            if (musicConfig.sounds[i].type == type)
            {
                music = musicConfig.sounds[i];
            }
        }
        if (music != null)
        {
            AudioSource soundSourceToPlay = musicSource;
            //if (soundSource1.isPlaying)
            //    soundSourceToPlay = soundSource2;
            soundSourceToPlay.volume = music.volume;
            soundSourceToPlay.clip = music.clip;
            soundSourceToPlay.Play( );
        }
    }
    public static void PlaySFXByType(SFXType type, float volumeFadeMultiplier = 1,bool isLoop = false)
    {
        if(!UserData.Ins.soundIsOn) return;

        if (Instant != null&& volumeFadeMultiplier>0.01 && type != SFXType.none)
        {
            if (Instant.lastTimePlayASound.ContainsKey(type))
            {
                if (Time.time - Instant.lastTimePlayASound[type] < 0.05f)
                {
                    return; //avoid play same sound multiple time at one frame
                }
            }
            Instant.PlaySFX(type, volumeFadeMultiplier, isLoop);

            if (Instant.lastTimePlayASound.ContainsKey(type))
            {
                Instant.lastTimePlayASound[type] = Time.time;
            }
            else
            {
                Instant.lastTimePlayASound.Add(type, Time.time);
            }
        }
    }
    // void PlayButtonSFX()
    // {
    //     this.PlaySFX(SFXType.btnClick);
    // }

    public static void PlayMusicByType(MusicType type)
    {
        if(!UserData.Ins.musicIson) return;

        if (Instant != null)
        {
            Instant.PlayMusic(type);
        }
    }
    public static void StopMusic( )
    {
        if (Instant != null)
        {
            Instant.musicSource.Pause();
        }
    }
    public static void PlayAlarm()
    {
        if (Instant != null)
        {
            Instant.alarmSource.Stop();
            Instant.alarmSource.Play();
        }
    }

    public static void SetMusicEnabled(bool isMusicOn)
    {
        if (Instant != null)
        {
            if(isMusicOn)
            {
                Instant.musicSource.Play();
            }
            else
            {
                Instant.musicSource.Pause();
            }
            
        }
    }



    public static void SetSoundEnabled(bool isSoundOn)
    {
        if (Instant != null)
        {
            if(isSoundOn)
            {
                Instant.soundSource1.Play();
            }
            else
            {
                Instant.soundSource1.Pause();
            }
            
        }
    }

    public static void SetAllSoundEnabled(bool state)
    {
        if (Instant != null)
        {
            if(state)
            {
                Instant.musicSource.Play();
                UserData.Ins.SetBoolData(UserData.Key_SoundIsOn, ref UserData.Ins.soundIsOn, state);
            }
            else
            {
                Instant.musicSource.Pause();
                UserData.Ins.SetBoolData(UserData.Key_SoundIsOn, ref UserData.Ins.soundIsOn, state);
            }

        }
    }
 
    
}
