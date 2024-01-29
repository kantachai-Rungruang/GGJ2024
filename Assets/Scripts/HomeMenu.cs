using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] private Button m_StartGameButton;
    [SerializeField] private Button m_SettingButton;
    [SerializeField] private Button m_CreditButton;
    [SerializeField] private Button m_QuitButton;
    [SerializeField] private GameObject m_Setting;
    [SerializeField] private GameObject m_Credit;
    
    [SerializeField] private GameObject m_Warp;
    [SerializeField] private GameObject m_Mock;
    [SerializeField] private GameObject m_Playable;

    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        m_SettingButton.onClick.AddListener(SettingPopUp);
        m_StartGameButton.onClick.AddListener(StartGame);
        m_CreditButton.onClick.AddListener(Credit);
        m_QuitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        m_Warp.SetActive(true);
        m_Mock.SetActive(false);
        m_Playable.SetActive(true);
        gameObject.SetActive(false);
        // SceneManager.LoadScene("DemoAek");
    }

    public void SettingPopUp()
    {
        m_Setting.SetActive(true);
    }

    public void Credit()
    {
        m_Credit.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
