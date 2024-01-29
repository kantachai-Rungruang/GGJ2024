using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlayerGameController player;

    // Example of how to call this method from another script when a player picks up an item
    public void AddItemToInventory(Item item)
    {
        player.gameManager.inventory.AddItem(item);
    }
}
