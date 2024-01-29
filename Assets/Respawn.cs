using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject stone;
    
    private void SpawnStone()
    {
        Instantiate(stone, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnStone();
        }
    }
}
