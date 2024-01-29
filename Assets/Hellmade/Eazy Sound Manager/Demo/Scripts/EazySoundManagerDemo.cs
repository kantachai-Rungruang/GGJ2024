using UnityEngine;
using UnityEngine.UI;
using Hellmade.Sound;
using TMPro;

public class EazySoundManagerDemo : MonoBehaviour
{
    public static EazySoundManagerDemo instance;
    public EazySoundDemoAudioControls[] AudioControls;
    public EazySoundDemoAudioControls[] SoundFxControls;
    public EazySoundDemoAudioControls[] MusicControls;
    public Slider globalVolSlider;
    public Slider globalMusicVolSlider;
    public Slider globalSoundVolSlider;

    public float SliderValue;
    public GameObject test;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        globalSoundVolSlider.value = SliderValue;
        globalMusicVolSlider.value = SliderValue;
    }
    private void Update ()
    {

    }

    public void PlaySound(int index)
    {
        EazySoundDemoAudioControls audioControl = SoundFxControls[index];

        if (audioControl.audio == null)
        {
            int audioID = EazySoundManager.PlaySound(audioControl.audioclip, 1f);
            SoundFxControls[index].audio = EazySoundManager.GetAudio(audioID);
        }
        else if (audioControl.audio != null && audioControl.audio.Paused)
        {
            audioControl.audio.Resume();
        }
        else
        {
            audioControl.audio.Play();
        }
    }

    public void PlayMusic(int index)
    {
        EazySoundDemoAudioControls audioControl = MusicControls[index];

        if (audioControl.audio == null)
        {
            int audioID = EazySoundManager.PlayMusic(audioControl.audioclip, 1f, true, false);
            MusicControls[index].audio = EazySoundManager.GetAudio(audioID);
        }
        else if (audioControl.audio != null && audioControl.audio.Paused)
        {
            audioControl.audio.Resume();
        }
        else
        {
            audioControl.audio.Play();
        }
    }

    public void Pause(string audioControlIDStr)
    {
        int audioControlID = int.Parse(audioControlIDStr);
        EazySoundDemoAudioControls audioControl = AudioControls[audioControlID];

        audioControl.audio.Pause();
    }

    public void Stop(string audioControlIDStr)
    {
        int audioControlID = int.Parse(audioControlIDStr);
        EazySoundDemoAudioControls audioControl = AudioControls[audioControlID];

        audioControl.audio.Stop();
    }

    public void GlobalVolumeChanged(float value)
    {
        EazySoundManager.GlobalVolume = value;
    }

    public void GlobalMusicVolumeChanged(float value)
    {
        EazySoundManager.GlobalMusicVolume = value;
    }

    public void GlobalSoundVolumeChanged(float value)
    {
        EazySoundManager.GlobalSoundsVolume = value;
    }
}

[System.Serializable]
public struct EazySoundDemoAudioControls
{
    public AudioClip audioclip;
    public Audio audio;
}
