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
    Vector3 startPosition;


     const string STATE_ALIVE = "isAlive";
     const string STATE_ON_THE_GROUND = "isOnTheGround";

    private int healthPoints, manaPoints;

    public const int INITIAL_HEALTH = 100, INITIAL_MANA =15, MAX_HEALTH = 200, MAX_MANA=30,
    MIN_HEALTH = 10, MIN_MANA = 0;


    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

   public void StartGame()
    {
        
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, false);

        healthPoints = INITIAL_HEALTH;
        manaPoints = INITIAL_MANA;

        Invoke("RestartPosition", 0.2f);
    }

    void RestartPosition()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;

        GameObject mainCamera = GameObject Find("Main Camera");
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

    public void Die()
    {
        float travelledDistance = GetTravelDistance();
        float previousMaxDistance = playerPrefs.GetFloat("maxscore", 0);

        if(travelledDistance > previousMaxDistance)
        {
        playerPrefs.SetFloat("maxscore", travelledDistance);
        }
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }

    public void CollectHealth(int points)
    {
        this.healthPoints += points;
        if(this.healthPoints >= MAX_HEALTH)
        {
            this.healthPoints = MAX_HEALTH;
        }

        if(this.healthPoints <= 0)
        {
            Die(); 
        }
    }

    public void CollectMana(int points)
    {
        this.manaPoints += points;
        if(this.manaPoints >= MAX_MANA)
        {
            this.manaPoints = MAX_MANA;
        }
    }

    public int GetHealth()
    {
        return healthPoints;
    }

    public int GetMana()
    {
        return manaPoints;
    }

    public float GetTravelDistance()
    {
        return this.transform.position.x - startPosition.x;
    }
}
