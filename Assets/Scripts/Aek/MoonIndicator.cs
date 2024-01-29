using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonIndicator : MonoBehaviour
{
    public Transform playerPoint;
    public Transform moonPivot;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float fullDistance;

    // Start is called before the first frame update
    void Start()
    {
        fullDistance = endPoint.position.x - startPoint.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CalculateDistance();
    }

    void CalculateDistance()
    {
        if (playerPoint)
        {
            float distance = (endPoint.position.x - playerPoint.position.x) - fullDistance;
            float value = Mathf.Clamp((distance / fullDistance) * 180f, -180f, 0f);
            moonPivot.rotation = Quaternion.Euler(0f, 0f, value);
        }
    }
}
