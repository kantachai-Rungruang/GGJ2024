using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCat : MonoBehaviour
{
    [SerializeField] private GameObject m_FxObj;
    [SerializeField] private SpriteRenderer m_Head;
    [SerializeField] private Sprite[] m_SpriteHead;
    public bool Feeding = false;
    [SerializeField] private LayerMask happy;

    public void GotFeed()
    {
        m_FxObj.SetActive(true);
        m_Head.sprite = m_SpriteHead[1];
        gameObject.layer = LayerMask.NameToLayer("HappyCat");
        gameObject.tag = "Untagged";
        gameObject.GetComponent<DamageObject>().isHappy = true;
        EazySoundManagerDemo.instance.PlaySound(18);
    }
}
