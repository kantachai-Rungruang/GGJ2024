using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private float m_TargetRotation;
    [SerializeField] private Rigidbody2D m_Rigid2D;
    [SerializeField] private float m_Force;

    public void Update()
    {
        m_Rigid2D.MoveRotation(Mathf.LerpAngle(m_Rigid2D.rotation, m_TargetRotation, m_Force * Time.deltaTime));
    }
}
