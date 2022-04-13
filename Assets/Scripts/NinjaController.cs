using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float velocityx = 15;
    public float jumpforcey = 40;
    public int limiteSalto = 2;
    
    private bool isAlive = false;
    private bool isDead = false;
    private int saltosHechos;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    
    private const int ANIMATION_RUN = 0;
    private const int ANIMATION_JUMP = 1;
    private const int ANIMATION_DEAD = 2; 
    private const int LAYER_SUELO = 10;
    
    private const string TAG_MATAR = "Enemy";
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            isAlive = false;
            rb.velocity = new Vector2(velocityx, rb.velocity.y);
            changeAnimaton(ANIMATION_RUN);

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (saltosHechos < limiteSalto)
                {
                    
                    rb.AddForce(Vector2.up * jumpforcey, ForceMode2D.Impulse);
                    saltosHechos++;
                }

                changeAnimaton(ANIMATION_JUMP);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D colision)
    {

        if (colision.gameObject.layer == LAYER_SUELO)
        {
            saltosHechos = 0;
        }

        if (colision.gameObject.CompareTag(TAG_MATAR) && !isAlive)
        {
            isDead = true; 
            changeAnimaton(ANIMATION_DEAD);
            rb.velocity = new Vector2(0, rb.velocity.y); 
        }
    }
    private void changeAnimaton(int animation)
    {
        anim.SetInteger("Estado", animation);
    } 
}
