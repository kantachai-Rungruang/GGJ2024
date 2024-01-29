using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Fish = 0;

    public void AddItem(Item item)
    {
        Fish += 1;
        GetComponent<GameManager>().FishCountCallback?.Invoke(Fish);
    }
    public void UseItem()
    {
        Fish -= 1;
        GetComponent<GameManager>().FishCountCallback?.Invoke(Fish);
    }
}
