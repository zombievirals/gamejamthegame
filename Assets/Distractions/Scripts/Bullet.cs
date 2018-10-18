using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Bullet : MonoBehaviour {


    public Vector2 speed;

    Rigidbody2D rb;

   
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;

    }

   
    void Update()
    {
        rb.velocity = speed;
        Destroy(gameObject, 3);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
        {
           Destroy(gameObject);
            
        } 
    }



}
