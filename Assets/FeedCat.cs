using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FeedCat : MonoBehaviour
{
    [SerializeField] private bool isFood = false;
    public GameObject food;
    public GameObject sprite;
    public PlayerGameController player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            if (!isFood && player.m_IndexHead == 2 && other.GetComponent<IsCat>())
            {
                if (!other.GetComponent<IsCat>().Feeding
                && player.gameManager.inventory.Fish > 0)
                {
                    player.gameManager.inventory.UseItem();
                    Vector3 pos = other.transform.position;
                    other.GetComponent<IsCat>().Feeding = true;
                    GameObject newFood = Instantiate(food, player.m_RigidHead.transform.position, Quaternion.identity);
                    newFood.transform.DOJump(
                                    endValue: pos,
                                    jumpPower: 0.5f,
                                    numJumps: 1,
                                    duration: 0.5f
                    ).SetEase(Ease.Linear).OnComplete(() => {
                        other.GetComponent<IsCat>().Feeding = false;
                        Destroy(newFood);
                    });
                }
            }
            else if (isFood && other.GetComponent<IsCat>())
            {
                other.GetComponent<IsCat>().GotFeed();
                sprite.SetActive(false);
            }
        }
    }
}
