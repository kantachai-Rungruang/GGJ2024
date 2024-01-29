using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EquipGUI : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private Transform[] btnHead;
    [SerializeField] private Transform[] btnBody;
    [SerializeField] private Transform[] btnLegs;
    [SerializeField] private Image sliderSpringX;
    [SerializeField] private Image sliderSpringY;
    [SerializeField] private TMP_Text fishCount;

    Vector3 scaleFocus = new Vector3(1.25f, 1.25f, 1f);
    Vector3 scaleUnfocus = new Vector3(1f, 1f, 1f);

    private void Start()
    {
        gameManager.SpringXCallback = UpdateSpringX;
        gameManager.SpringYCallback = UpdateSpringY;
        gameManager.UnlockHeadCallback = UnlockHead;
        gameManager.UnlockBodyCallback = UnlockBody;
        gameManager.UnlockLegsCallback = UnlockLegs;
        gameManager.FishCountCallback = FishCount;
    }

    public void FishCount(int index)
    {
        fishCount.text = "Fish: " + index.ToString("N0");
    }

    public void UnlockHead(int index)
    {
        btnHead[index].GetComponent<Button>().interactable = true;
        if (index == 1)
        {
            fishCount.gameObject.SetActive(true);
            FishCount(0);
        }
    }

    public void UnlockBody(int index)
    {
        btnBody[index].GetComponent<Button>().interactable = true;
    }

    public void UnlockLegs(int index)
    {
        btnLegs[index].GetComponent<Button>().interactable = true;
    }

    public void OnClickHead(int index)
    {
        if (index == 0)
        {
            btnHead[0].DOScale(scaleFocus, 1);
            btnHead[1].DOScale(scaleUnfocus, 1);
        }
        else
        {
            btnHead[0].DOScale(scaleUnfocus, 1);
            btnHead[1].DOScale(scaleFocus, 1);
        }
        gameManager.currentLife.GetComponent<PlayerGameController>().EquipHead(index + 1);
    }

    public void OnClickBody(int index)
    {
        if (index == 0)
        {
            btnBody[0].DOScale(scaleFocus, 1);
            btnBody[1].DOScale(scaleUnfocus, 1);
        }
        else
        {
            btnBody[0].DOScale(scaleUnfocus, 1);
            btnBody[1].DOScale(scaleFocus, 1);
        }
        gameManager.currentLife.GetComponent<PlayerGameController>().EquipBody(index + 1);
    }

    public void OnClickLegs(int index)
    {
        if (index == 0)
        {
            btnLegs[0].DOScale(scaleFocus, 1);
            btnLegs[1].DOScale(scaleUnfocus, 1);
        }
        else
        {
            btnLegs[0].DOScale(scaleUnfocus, 1);
            btnLegs[1].DOScale(scaleFocus, 1);
        }
        sliderSpringX.transform.parent.gameObject.SetActive(index == 0);
        sliderSpringY.transform.parent.gameObject.SetActive(index == 0);
        sliderSpringX.fillAmount = 0;
        sliderSpringY.fillAmount = 0;
        gameManager.currentLife.GetComponent<PlayerGameController>().EquipLegs(index + 1);
    }

    public void UpdateSpringX(float value)
    {
        sliderSpringX.fillAmount = value;
    }

    public void UpdateSpringY(float value)
    {
        sliderSpringY.fillAmount = value;
    }
}
