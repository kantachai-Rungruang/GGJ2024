using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIgame : MonoBehaviour
{
    public void Start()
    {
        EazySoundManagerDemo.instance.PlayMusic(0);
        EazySoundManagerDemo.instance.PlaySound(2);
    }
    // Start is called before the first frame update
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
