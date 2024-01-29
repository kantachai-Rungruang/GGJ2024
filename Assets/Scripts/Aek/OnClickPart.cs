using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickPart : MonoBehaviour
{
    [SerializeField] private string partName;
    [SerializeField] private PlayerGameController playerController;

    void OnMouseDown()
    {
        playerController.OnClickPart(partName);
    }

    void OnMouseUp()
    {
        playerController.OnPartUp();
    }
}
