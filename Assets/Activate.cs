using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEditor.Progress;

public class Activate : MonoBehaviour
{
    [SerializeField] private GameObject m_StoneWall;
    [SerializeField] private bool m_IsStay = false;
    [SerializeField] private float m_Pos;
    [SerializeField] private float m_PosOut;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_StoneWall.transform.DOMoveY(m_Pos, 2f, false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!m_IsStay && other.gameObject.CompareTag("Player"))
        {
            m_StoneWall.transform.DOMoveY(m_Pos, 2f, false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!m_IsStay && other.gameObject.CompareTag("Player"))
        {
            m_StoneWall.transform.DOMoveY(m_PosOut, 2f, false);
        }
    }

    
}
