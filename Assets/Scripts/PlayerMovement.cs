using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool canRun;
    
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        GameManager.instance.IsCountingSwitcher();

        canRun = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate() {
        if (canRun) {
            Moving();
        }
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

    IEnumerator Delay() {
        animator.SetBool("isDead", true);
        canRun = false;
        GameManager.instance.paper = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("P203");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ghost") && ConversationManager.nextConversation == 3) {
            StartCoroutine(Delay());
        }
    }
}
