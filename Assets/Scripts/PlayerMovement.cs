using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject paperDone;
    [SerializeField] private Image _whiteFade;
    
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
            GameManager.instance.Score();
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
        PlayerPrefs.DeleteAll();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("P203");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ghost")) {
            StartCoroutine(Delay());
        }
        if (other.gameObject.CompareTag("Ending")) {
            _whiteFade.gameObject.SetActive(true);
            StartCoroutine(EndingTime());
        }
    }

    IEnumerator EndingTime() {
        GameManager.instance.canRun = false;
        animator.SetFloat("isRunning", 0);
        enemy.SetActive(true);
        yield return new WaitForSeconds(5.7f);
        paperDone.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.7f);
        float t = 0f;
        while (t < 2)
        {
            t += Time.deltaTime;
            Color color = _whiteFade.color;
            color.a = t / 1;
            _whiteFade.color = color;
            GameManager.instance.IsCountingSwitcher();
            yield return null;
        }
        SceneManager.LoadScene("Ending");
    }
}
