using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // Variables del movimiento del personaje
    public float jumpForce = 6f;
    private Rigidbody2D rigidBody;

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
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
    
    //Método para saltar
    void Jump()
    {
        rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }
}
