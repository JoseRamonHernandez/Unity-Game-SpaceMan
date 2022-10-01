using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // Variables del movimiento del personaje
    public float jumpForce = 6f;
    Rigidbody2D rigidBody;

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        Jump();
    }

    //Método para saltar
    void Jump()
    {
        if(IsTouchingTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            //TODO: programar lógica de contacto con el suelo
            return true;
        }
        else
        {
            //TODO: programar lógica de no contacto
            return false;
        }
    }
}
