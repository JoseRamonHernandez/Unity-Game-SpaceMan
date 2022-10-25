using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float runningSpeed = 1.5f;

    RigiBody2D rigiBody;

    public bool facingRight = false;

    private Vector3 startPositon;

    private void Awake()
    {
        rigiBody = GetComponent<RigiBody2D>();
        startPositon = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = startPositon;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float currentRunningSpeed = runningSpeed;

        if(facingRight)
        {
            currentRunningSpeed = runningSpeed;
            this.transform.eulerAngles = new Vector3(0,180,0);
        }
        else
        {
            currentRunningSpeed = -runningSpeed;
            this.transform.eulerAngles = Vector3.zero;
        }

        if(GameManager.sharedInstance.currentRunningSpeed == GameState.inGame)
        {
            rigiBody.velocity = new Vector2(currentRunningSpeed, rigiBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.log(collision.tag);

        if(collision.tag == "Coin")
        {
            return;
        }

        if(collision.tag == "Player")
        {
            collision.GameObject.GetComponent<PlayerController>().CollectHealth(-10);

            return;
        }

        facingRight = !facingRight;

    }
}
 