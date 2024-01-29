using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetting : MonoBehaviour
{
    public void OnVolumeChanged(float value)
    {
        EazySoundManager.GlobalVolume = value;
    }

    public void OnMusicVolumeChanged(float value)
    {
        EazySoundManager.GlobalMusicVolume = value;
    }

    public void OnSoundVolumeChanged(float value)
    {
        EazySoundManager.GlobalSoundsVolume = value;
    }
}
