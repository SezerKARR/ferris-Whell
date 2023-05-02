using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D RigidBody2D;
    private float x, y;
    private void Awake()
    {
         
        RigidBody2D = GetComponent<Rigidbody2D>();
        x = transform.position.x;
        y = transform.position.y-1;
    }
    private void Update()
    {

        

        RigidBody2D.velocity = new Vector2(x, y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            
            Destroy(gameObject);
        }
    }
}