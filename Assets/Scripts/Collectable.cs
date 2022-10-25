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


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
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
                break;
            case CollectableType.manaPotions:
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
