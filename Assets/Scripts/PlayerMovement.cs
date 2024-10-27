using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject paperDone;
    
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        GameManager.instance.canRun = true;

        if (GameManager.instance.paper == 4 && SceneManager.GetActiveScene().name == "Floor 1") {
            paperDone.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Ending") {
            GameManager.instance.canRun = true;
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate() {
        if (GameManager.instance.canRun) {
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
        animator.SetTrigger("isDead");
        GameManager.instance.canRun = false;
        GameManager.instance.paper = 0;
        GameManager.instance.beeBadge = 0;
        GameManager.instance.hasRead = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("P203");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ghost") && ConversationManager.nextConversation == 3) {
            StartCoroutine(Delay());
        }
        if (other.gameObject.CompareTag("Ending")) {
            StartCoroutine(EndingTime());
        }
    }

    IEnumerator EndingTime() {
        GameManager.instance.canRun = false;
        animator.SetFloat("isRunning", 0);
        enemy.SetActive(true);
        yield return new WaitForSeconds(5f);
        paperDone.GetComponent<SpriteRenderer>().enabled = true;
        Time.timeScale = 0;
        GameManager.instance.ChangeScene("Ending");
    }
}
