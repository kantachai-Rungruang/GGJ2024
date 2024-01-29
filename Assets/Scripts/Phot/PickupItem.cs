using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            InventoryManager inventoryManager = other.GetComponent<InventoryManager>();
            if (inventoryManager != null)
            {
                switch(item.itemName) 
                {
                case "Fish":
                    if (inventoryManager.player.m_IndexHead == 2)
                    {
                        inventoryManager.AddItemToInventory(item);
                        EazySoundManagerDemo.instance.PlaySound(3);
                        gameObject.SetActive(false);
                    }
                    break;
                case "Head1":
                    inventoryManager.player.gameManager.UnlockHeadCallback.Invoke(0);
                    EazySoundManagerDemo.instance.PlaySound(3);
                    Destroy(gameObject);
                    break;
                case "Head2":
                    inventoryManager.player.gameManager.UnlockHeadCallback.Invoke(1);
                    EazySoundManagerDemo.instance.PlaySound(3);
                    Destroy(gameObject);
                    break;
                case "Body1":
                    inventoryManager.player.gameManager.UnlockBodyCallback.Invoke(0);
                    EazySoundManagerDemo.instance.PlaySound(3);
                    Destroy(gameObject);
                    break;
                case "Body2":
                    inventoryManager.player.gameManager.UnlockBodyCallback.Invoke(1);
                    EazySoundManagerDemo.instance.PlaySound(3);
                    Destroy(gameObject);
                    break;
                case "Legs1":
                    inventoryManager.player.gameManager.UnlockLegsCallback.Invoke(0);
                    EazySoundManagerDemo.instance.PlaySound(3);
                    Destroy(gameObject);
                    break;
                case "Legs2":
                    inventoryManager.player.gameManager.UnlockLegsCallback.Invoke(1);
                    EazySoundManagerDemo.instance.PlaySound(3);
                    Destroy(gameObject);
                    break;
                default:
                    // code block
                    break;
                }
            }
        }
    }
}
