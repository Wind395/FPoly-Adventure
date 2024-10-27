using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCs : MonoBehaviour
{
    public Transform player;
    [SerializeField] private GameObject chatboxUI;

    [SerializeField] private GameObject beeFPoly;

    [SerializeField] private GameObject eButton;

    public Animator animator;

    [SerializeField] private AudioSource girl;
    private SpriteChange  spriteChange;

    [SerializeField] private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Conversation();
        }

        // Sử dụng các biến dưới để so sánh và chạy Animation,...
        if (ConversationManager.nextConversation == 0 && ConversationManager.currentConversationIndex >= 6) {
            animator.SetBool("IsAction", true);
        }
        if (ConversationManager.nextConversation == 0 && ConversationManager.currentConversationIndex >= 9) {
            animator.SetBool("IsAction", false);
        }
        if (ConversationManager.nextConversation == 2 && ConversationManager.currentConversationIndex >= 12) {
            beeFPoly.SetActive(false);
        }
        if (ConversationManager.nextConversation == 3) {
            beeFPoly.SetActive(false);
        }

        if (ConversationManager.nextConversation == 3 && ConversationManager.currentConversationIndex == 6) {
            Debug.Log("Change");
            sprite.flipX = false;
        }
    }

    void Conversation() {
        // Tiến gần để nói chuyện
        if (Vector2.Distance(transform.position, player.position) < 2) {
            switch (ConversationManager.nextConversation) {
                // So sánh các điều kiện để nói chuyện với NPC tiếp theo, tránh bị trùng lặp
                case 0:
                    if (gameObject.CompareTag("Girl") &&  !GameManager.instance.isGirl) {
                        chatboxUI.SetActive(true);
                        Debug.Log(ConversationManager.currentConversationIndex);
                        ConversationManager.Instance.LoadConversation("conversation1");
                        if (chatboxUI.activeSelf == false) {
                            GameManager.instance.isGirl = true;
                        }
                    }
                    break;
                case 1:
                    if (gameObject.CompareTag("Door") && !GameManager.instance.isDoor) {
                        chatboxUI.SetActive(true);
                        ConversationManager.Instance.LoadConversation("conversation2");
                        if (chatboxUI.activeSelf == false) {
                            GameManager.instance.isDoor = true;
                        }
                    }
                    break;
                case 2:
                    if (gameObject.CompareTag("Golden Bee") && !GameManager.instance.isBee) {
                        chatboxUI.SetActive(true);
                        ConversationManager.Instance.LoadConversation("conversation3");
                        if (chatboxUI.activeSelf == false) {
                            GameManager.instance.isBee = true;
                        }
                    }
                    break;
                case 3:
                    if (gameObject.CompareTag("Boy") && SceneManager.GetActiveScene().name == "Ending") {
                        GameManager.instance.canRun = false;
                        chatboxUI.SetActive(true);
                        ConversationManager.Instance.LoadConversation("conversation4");
                        if (chatboxUI.activeSelf == false) {
                            GameManager.instance.endUI.SetActive(true);
                        }
                    }
                    break;
            }
            // Chuyển câu nói chuyện tiếp theo
            ConversationManager.Instance.GetNextConversation(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Girl") || other.gameObject.CompareTag("Door") ||  other.gameObject.CompareTag("Golden Bee") || other.gameObject.CompareTag("Boy")) {
            eButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Girl") || other.gameObject.CompareTag("Door") ||  other.gameObject.CompareTag("Golden Bee") || other.gameObject.CompareTag("Boy")) {
            eButton.SetActive(false);
        }
    }
}
