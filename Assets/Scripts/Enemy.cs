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
    void Update()
    {
        
    }
}
