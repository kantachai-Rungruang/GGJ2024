using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public void PlaySound(int index)
    {
        EazySoundManagerDemo.instance.PlaySound(index);
    }
}
