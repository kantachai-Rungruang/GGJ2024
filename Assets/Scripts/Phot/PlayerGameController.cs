using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGameController : MonoBehaviour
{
    public GameManager gameManager;
    public Transform playerPos;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask water;
    [SerializeField] private LayerMask layerNull;
    [SerializeField] private LayerMask hide;
    [SerializeField] private bool isArrive = true;
    [SerializeField] private bool is_UseHand = false;
    [SerializeField] private bool is_UseWing = false;
    [SerializeField] private bool is_UseSpring = false;

    [SerializeField] private Animator m_Animator;
    public Rigidbody2D m_RigidHand;
    public Rigidbody2D m_RigidBody;
    public Rigidbody2D m_RigidHead;
    [SerializeField] private float dragForce;

    [SerializeField] private bool isHiding;
    [SerializeField] private bool isFlying;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isGround;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 minJumpForce;
    [SerializeField] private Vector2 maxJumpForce;
    Vector2 jumpingForce;
    Vector3 startJumpPoint;
    Vector3 endJumpPoint;
    Vector3 velocity = Vector3.zero;
    
    [SerializeField] private float lastClickTime;

    [SerializeField] private SpriteRenderer m_RenderHead;
    [SerializeField] private SpriteRenderer m_RenderBody;
    [SerializeField] private SpriteRenderer[] m_RenderLegs;
    [SerializeField] private Sprite[] m_SpriteHead;
    [SerializeField] private Sprite[] m_SpriteBody;
    [SerializeField] private Sprite[] m_SpriteLLegs;
    [SerializeField] private Sprite[] m_SpriteRLegs;
    public int m_IndexHead;
    public int m_IndexBody;
    public int m_IndexLegs;

    [SerializeField] private GameObject[] m_LightLegs;
    [SerializeField] private GameObject m_FeedCat;
    [SerializeField] private GameObject m_Turtle;
    [SerializeField] private GameObject m_Follow;
    [SerializeField] private GameObject m_Particale;

    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }

        ResetUsing();
        isJumping = false;
        isArrive = true;
        isGround = true;
    }

    public void EquipHead(int costume)
    {
        EazySoundManagerDemo.instance.PlaySound(16);
        m_RenderHead.sprite = m_SpriteHead[costume];
        m_IndexHead = costume;

        if (costume == 1)
        {
            m_FeedCat.SetActive(false);
            m_RigidHead.includeLayers = water;
        }
        else
        {
            m_FeedCat.SetActive(true);
            m_RigidHead.includeLayers = layerNull;
        }
    }

    public void EquipBody(int costume)
    {
        EazySoundManagerDemo.instance.PlaySound(16);
        m_RenderBody.sprite = m_SpriteBody[costume];
        m_IndexBody = costume;
    }

    public void EquipLegs(int costume)
    {
        EazySoundManagerDemo.instance.PlaySound(16);
        m_RenderLegs[0].sprite = m_SpriteLLegs[costume];
        m_RenderLegs[1].sprite = m_SpriteRLegs[costume];
        m_IndexLegs = costume;

        for (int i = 0; i < m_LightLegs.Length; i++)
        {
            m_LightLegs[i].SetActive(m_IndexLegs == 2);
        }
    }

    void ResetUsing()
    {
        is_UseHand = false;
        is_UseWing = false;
        is_UseSpring = false;
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(playerPos.position, 0.3f, ground);

        if (is_UseHand && Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 dir = m_RigidHand.position - (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
            dir.x = Mathf.Clamp(dir.x, -2f, 2f);
            dir.y = Mathf.Clamp(dir.y, -2f, 2f);
            m_RigidHand.AddForce(-dir * dragForce * Time.deltaTime * 1000f);

            if(isGround == true)
            {
                if (dir.x > 0)
                {
                    m_Animator.Play("Walk");
                }
                else
                {
                    m_Animator.Play("WalkBack");
                }
            }

        }
        else if (m_IndexLegs == 1 && is_UseSpring && isGround == true
        && Input.GetKey(KeyCode.Mouse0))
        {
            isJumping = true;
            ResetUsing();
            EazySoundManagerDemo.instance.PlaySound(14);
            startJumpPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
        }
        else if (m_IndexLegs == 1 && !is_UseSpring && isJumping == true && isGround == true
        && Input.GetKey(KeyCode.Mouse0))
        {
            endJumpPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));

            jumpingForce = new Vector2(Mathf.Clamp(startJumpPoint.x - endJumpPoint.x, minJumpForce.x, maxJumpForce.x), 
                                        Mathf.Clamp(startJumpPoint.y - endJumpPoint.y, minJumpForce.y, maxJumpForce.y));

            gameManager.SpringXCallback.Invoke(Mathf.Abs(jumpingForce.x / maxJumpForce.x));
            gameManager.SpringYCallback.Invoke(Mathf.Abs(jumpingForce.y / maxJumpForce.y));
        }
        else if (!is_UseHand && !is_UseSpring && m_IndexBody == 1
        && Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= 0.2f)
            {
                isHiding = true;
            }
            lastClickTime = Time.time;
        }
        else if (!is_UseHand && !is_UseSpring && m_IndexBody == 1
        && isHiding && Input.GetKey(KeyCode.Mouse0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            m_Turtle.SetActive(isHiding);
            if (timeSinceLastClick <= 0.2f)
            {
                Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].GetComponent<Collider2D>() != null)
                    {
                        colliders[i].GetComponent<Collider2D>().excludeLayers = hide;
                    }
                    if (colliders[i].GetComponent<SpriteRenderer>() != null)
                    {
                        colliders[i].GetComponent<SpriteRenderer>().enabled = !isHiding;
                    }
                }
            }
            lastClickTime = Time.time;
        }
        else if (!is_UseHand && !is_UseSpring && m_IndexBody == 1
        && isHiding && Input.GetMouseButtonUp(0))
        {
            isHiding = false;
            m_Turtle.SetActive(isHiding);
            Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].GetComponent<Collider2D>() != null)
                {
                    colliders[i].GetComponent<Collider2D>().excludeLayers = water;
                }
                if (colliders[i].GetComponent<SpriteRenderer>() != null)
                {
                    colliders[i].GetComponent<SpriteRenderer>().enabled = !isHiding;
                }
            }
        }
        else if (!is_UseHand && !is_UseSpring && m_IndexBody == 2
        && Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= 0.2f)
            {
                isFlying = true;
            }
            lastClickTime = Time.time;
        }
        else if (!is_UseHand && !is_UseSpring && m_IndexBody == 2
        && isFlying && Input.GetKey(KeyCode.Mouse0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if (timeSinceLastClick <= 0.2f)
            {
                Vector2 dir = m_RigidBody.position - (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
                dir.x = Mathf.Clamp(dir.x, -1f, 1f);
                dir.y = Mathf.Clamp(dir.y, -5f, 10f);
                m_RigidBody.AddForce(-dir * dragForce * Time.deltaTime * 1000f);
            }
            lastClickTime = Time.time;
        }
        else if (!is_UseHand && !is_UseSpring && m_IndexBody == 2
        && isFlying && Input.GetMouseButtonUp(0))
        {
            isFlying = false;
        }
        else
        {

            if (isGround == false)
            {
                m_Animator.Play("Jumping");
            }
            else
            {
                m_Animator.Play("Idle");
            }
        }

        if (isJumping && Input.GetMouseButtonUp(0) && isGround == true)
        {
            isJumping = false;
            isGround = false;
            ResetUsing();
            endJumpPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));

            jumpingForce = new Vector2(Mathf.Clamp(startJumpPoint.x - endJumpPoint.x, minJumpForce.x, maxJumpForce.x), 
                                        Mathf.Clamp(startJumpPoint.y - endJumpPoint.y, minJumpForce.y, maxJumpForce.y));
            jumpingForce.y = jumpingForce.y * 2f;
            m_RigidBody.AddForce(jumpingForce * jumpForce, ForceMode2D.Impulse);
            EazySoundManagerDemo.instance.PlaySound(15);
        }
        m_Follow.transform.position = playerPos.position;
    }

    public void OnClickPart(string partName)
    {
        Debug.Log(partName);
        switch(partName) 
        {
        case "Hand":
            is_UseHand = true;
            break;
        case "Leg":
            is_UseSpring = true;
            break;
        default:
            ResetUsing();
            break;
        }
    }

    public void OnPartUp()
    {
        if (is_UseHand || is_UseWing || is_UseSpring)
        {
            ResetUsing();
        }
    }

    public void OnTakeDMG()
    {
        if (isArrive)
        {
            isArrive = false;
            EazySoundManagerDemo.instance.PlaySound(Random.Range(11, 13));
            Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].gameObject.tag = "Untagged";

                if (colliders[i].GetComponent<HingeJoint2D>() != null)
                {
                    colliders[i].GetComponent<HingeJoint2D>().enabled = false;
                }
                
                if (colliders[i].GetComponent<Balance>() != null)
                {
                    colliders[i].GetComponent<Balance>().enabled = false;
                }

                if (colliders[i].GetComponent<FixedJoint2D>() != null)
                {
                    colliders[i].GetComponent<FixedJoint2D>().enabled = false;
                }

                if (colliders[i].GetComponent<Collider2D>() != null)
                {
                    colliders[i].GetComponent<Collider2D>().includeLayers = layerNull;
                }

                if (colliders[i].GetComponent<Rigidbody2D>() != null)
                {
                    Vector2 deathForce = new Vector2(Random.Range(0.5f, 2f), Random.Range(0.5f, 4f));
                    colliders[i].GetComponent<Rigidbody2D>().AddForce(deathForce, ForceMode2D.Impulse);
                }
            }
            m_Particale.SetActive(true);
            Vector3 pos = gameObject.transform.position;
            pos.z = pos.z + (0.5f * Random.Range(-2,1));
            gameObject.transform.DOJump(
                                    endValue: pos,
                                    jumpPower: 0.25f,
                                    numJumps: 1,
                                    duration: 1f
                    ).SetEase(Ease.Linear).OnComplete(() => {
                        gameManager.CharacterIsDeath();
                    });
        }
    }
}
