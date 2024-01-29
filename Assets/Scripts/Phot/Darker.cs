using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // other.gameObject.transform.parent.GetComponent<PlayerGameController>().gameManager.SpawnSecondLife();
            other.gameObject.transform.parent.GetComponent<PlayerGameController>().gameManager.SetDarker();
        }
    }
}
