using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType{
    healthPotion,
    manaPotions,
    money
}


public class Colectable : MonoBehaviour
{

    public CollectableType type = CollectableType.money;

    private SpriteRenderer sprite;
    private CircleCollider2D itemCollider;
    
    bool hasBeenCollected = false;

    public int value = 1;

    GameObject player;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Show()
    {
        sprite.enable = true;
        itemCollider.enable = true;
        hasBeenCollected = false;
    }

    void Hide()
    {
        sprite.enable = false;
        itemCollider.enable = false;
    }

    void Collect()
    {
        Hide();
        hasBeenCollected = true;

        switch(this.type)
        {
            case CollectableType.money:
                    GameManager.sharedInstance.CollectObject(this);
                break;
            case CollectableType.healthPotion:
                    //GameObject player = GameObject.Find("Player");
                    player.GetComponent<playerController>().CollectHealth(this.value);
                break;
            case CollectableType.manaPotions:
                    //GameObject player = GameObject.Find("Player");
                    player.GetComponent<playerController>().CollectMana(this.value);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Collect();
        }
    }
}
