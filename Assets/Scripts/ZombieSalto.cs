using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSalto : MonoBehaviour
{
    public float jumpforcey = 40;
    private Rigidbody2D rb;
    
    private const int LAYER_SUELO = 10;
    private const string TAG_SALTO = "Salto";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.layer ==LAYER_SUELO)
        { 
            
            jumpforcey = 10;
            rb.AddForce(Vector2.up * jumpforcey, ForceMode2D.Impulse); 
        }
        if (colision.gameObject.tag == TAG_SALTO)
        {
            
            jumpforcey = 0;
        }
    }
}
