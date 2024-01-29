using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBot : MonoBehaviour
{
    [SerializeField] GameObject m_PointA;
    [SerializeField] GameObject m_PointB;

    private Rigidbody2D rigid2D;

    private Animator anim;

    private Transform currentPoint;

    [SerializeField] float m_Speed;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = m_PointB.transform;
        anim.SetBool("isRunning", true);
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == m_PointB.transform)
        {
            rigid2D.velocity = new Vector2 (m_Speed, 0);
        }
        else
        {
            rigid2D.velocity = new Vector2 (-m_Speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == m_PointB.transform)
        {
            Flip();
            currentPoint = m_PointA.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == m_PointA.transform)
        {
            Flip();
            currentPoint = m_PointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(m_PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(m_PointB.transform.position, 0.5f);
        Gizmos.DrawLine(m_PointA.transform.position, m_PointB.transform.position);
    }
}
