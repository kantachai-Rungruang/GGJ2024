using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SupanthaPaul;

public class GameManager : MonoBehaviour
{
    public int spawnIndex;
    public GameObject Light;
    public SpawnPoint[] spawnPoint;
    public Inventory inventory;
    public CameraFollow m_Camera;
    public MoonIndicator m_Moon;
    public GameObject character;
    public GameObject currentLife;
    public GameObject secondLife;
    public Action<float> SpringXCallback;
    public Action<float> SpringYCallback;
    public Action<int> UnlockHeadCallback;
    public Action<int> UnlockBodyCallback;
    public Action<int> UnlockLegsCallback;
    public Action<int> FishCountCallback;

    private void Start()
    {
        currentLife = Instantiate(character, character.transform.position, Quaternion.identity);
        EazySoundManagerDemo.instance.PlayMusic(0);
        StartLife();
    }

    public void StartLife()
    {
        currentLife.SetActive(true);
        currentLife.GetComponent<PlayerGameController>().gameManager = this;

        m_Camera.SetTarget(currentLife.GetComponent<PlayerGameController>().playerPos);
        m_Moon.playerPoint = currentLife.GetComponent<PlayerGameController>().playerPos;
        m_Moon.moonPivot = m_Camera.moon;
        
        SpawnSecondLife();
    }

    public void CharacterIsDeath()
    {
        GameObject oldLife = currentLife;
        currentLife.GetComponent<PlayerGameController>().enabled = false;

        Vector3 pos = spawnPoint[spawnIndex].transform.position;
        pos.y += 2.5f;
        currentLife = Instantiate(character, pos, Quaternion.identity);;
        StartLife();
    }

    public void SetSpawnIndex(int _index)
    {
        spawnIndex = _index;
    }

    public void SetDarker()
    {
        Light.SetActive(false);
    }

    public void SetLight()
    {
        Light.SetActive(true);
    }

    public void SpawnSecondLife()
    {
        if (secondLife != null)
        {
            Destroy(secondLife);
        }
        secondLife = Instantiate(currentLife, currentLife.transform.position, Quaternion.identity);
        secondLife.SetActive(false);
    }

    public void UseFish()
    {
        inventory.Fish -= 1;
        if (inventory.Fish < 0)
        {
            inventory.Fish = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SetSpawnIndex(0);
            currentLife.GetComponent<PlayerGameController>().OnTakeDMG();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSpawnIndex(1);
            currentLife.GetComponent<PlayerGameController>().OnTakeDMG();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSpawnIndex(2);
            currentLife.GetComponent<PlayerGameController>().OnTakeDMG();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSpawnIndex(3);
            currentLife.GetComponent<PlayerGameController>().OnTakeDMG();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSpawnIndex(4);
            currentLife.GetComponent<PlayerGameController>().OnTakeDMG();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetSpawnIndex(5);
            currentLife.GetComponent<PlayerGameController>().OnTakeDMG();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UnlockHeadCallback.Invoke(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            UnlockHeadCallback.Invoke(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UnlockBodyCallback.Invoke(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnlockBodyCallback.Invoke(1);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            UnlockLegsCallback.Invoke(0);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            UnlockLegsCallback.Invoke(1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetDarker();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetLight();
        }
    }
}
