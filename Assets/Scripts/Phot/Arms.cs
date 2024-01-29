using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    private int m_Speed = 300;
    [SerializeField] private Rigidbody2D m_Rigid2D;
    public Camera m_Camera;
    [SerializeField] private KeyCode m_MouseButton;

    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    Vector3 dragStartPos;
    Touch touch;

    void Update()
    {
        //Vector3 playerPos = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 difference = playerPos - transform.position;
        //float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        //if(Input.GetKey(m_MouseButton))
        //{
        //    m_Rigid2D.MoveRotation(Mathf.LerpAngle(m_Rigid2D.rotation, rotationZ, m_Speed * Time.deltaTime));
        //}

        //Debug.Log(Input.mousePosition);

        if (Input.GetButtonDown("Mouse0"))
        {

        }

        void DragStart()
        {

        }
        void Dragging()
        {

        }
    }
}
