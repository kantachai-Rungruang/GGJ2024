using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public bool isPlayer = false;
    public bool isHappy = false;
    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (!isPlayer && !isHappy)
        {
            if (collision.gameObject.CompareTag("Player")) 
            {
                collision.gameObject.transform.parent.GetComponent<PlayerGameController>().OnTakeDMG();
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayer)
        {
            if (other.gameObject.CompareTag("Enemy")) 
            {
                Destroy(other.gameObject);
            }
        }
    }
}
