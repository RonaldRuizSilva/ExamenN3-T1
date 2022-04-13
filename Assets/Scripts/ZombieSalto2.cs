using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSalto2 : MonoBehaviour
{
    public float jumpforcey = 40;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    private const int LAYER_SUELO = 10;
    private const string TAG_SALTO = "Salto";
    private const string TAG_PAREDI = "PIzquierda";
    private const string TAG_PAREDD = "PDerecha";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnCollisionEnter2D(Collision2D colision)
    {
        
        rb.velocity = new Vector2(-1, rb.velocity.y); 
        if (colision.gameObject.CompareTag(TAG_PAREDI))
        {
            
        }
        if (colision.gameObject.CompareTag(TAG_PAREDD))
        {
            
            
        } 
        if (colision.gameObject.layer ==LAYER_SUELO)
        { 
            jumpforcey = 7;
            rb.AddForce(Vector2.up * jumpforcey, ForceMode2D.Impulse); 
        }
        if (colision.gameObject.CompareTag(TAG_SALTO))
        {
            jumpforcey = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TAG_PAREDI))
        {

            sr.flipX = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.velocity = new Vector2(3, rb.velocity.y);
        }

        if (other.gameObject.CompareTag(TAG_PAREDD))
        {

            sr.flipX = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
    }
}
