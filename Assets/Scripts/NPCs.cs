using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCs : MonoBehaviour
{
    public Transform player;
    [SerializeField] private GameObject chatboxUI;

    [SerializeField] private GameObject beeFPoly;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if (ConversationManager.nextConversation == 0 && ConversationManager.currentConversationIndex >= 8) {
            animator.SetBool("IsAction", false);
        }

        if (ConversationManager.nextConversation == 2 && ConversationManager.currentConversationIndex >= 11) {
            beeFPoly.SetActive(false);
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
                        ConversationManager.Instance.LoadConversation("conversation2");
                        chatboxUI.SetActive(true);
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
            }
            // Chuyển câu nói chuyện tiếp theo
            ConversationManager.Instance.GetNextConversation(); 
        }
    }
}
