using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int spawnIndex;
    [SerializeField] private GameObject[] m_fx;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !m_fx[0].activeSelf)
        {
            // other.gameObject.transform.parent.GetComponent<PlayerGameController>().gameManager.SpawnSecondLife();
            other.gameObject.transform.parent.GetComponent<PlayerGameController>().gameManager.SetSpawnIndex(spawnIndex);
            for (int i = 0; i < m_fx.Length; i++)
            {
                m_fx[i].SetActive(true);
            }
        }
    }
}
