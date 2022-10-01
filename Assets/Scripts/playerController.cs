using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // Variables del movimiento del personaje
    public float jumpForce = 6f;
    public float runningSpeed = 1.5f;
    Rigidbody2D rigidBody;
    Animator animator;


    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
        Jump();}

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());

        Debug.DrawRay(this.transform.position, Vector2.down*1.5f, Color.green);
    }

    void FixedUpdate()
    {   
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if(rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }
        else{
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }


    //Método para saltar
    void Jump()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if(IsTouchingTheGround())
            {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    // Método encargado de regresar un valor si el personaje esta tocando el suelo
    bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position, 
                            Vector2.down, 
                            1.5f, 
                            groundMask))
        {
            return true;
        }
        else
        {
            //TODO: programar lógica de no contacto
            //animator.enabled = false;
            return false;
        }
    }
}
