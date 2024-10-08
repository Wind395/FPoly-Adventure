using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        Moving();
    }
    private void Moving() {
        float x =  Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(speed * x, rb2d.velocity.y);
        animator.SetFloat("isRunning", Mathf.Abs(x));
        if (x > 0) {
            spriteRenderer.flipX = false;
        } 
        if (x < 0) {
            spriteRenderer.flipX = true;
        }
    }   
}
