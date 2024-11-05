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



    [SerializeField] private GameObject imgUI;
    [SerializeField] private AudioSource audioClip;
    private bool actionTriggered = false;

    public BoxCollider2D BoxCollider2D;

    void Start()
    {
        animator = GetComponent<Animator>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Conversation();
        }

        if (GameManager.instance.isGirl && !GameManager.instance.isDoor)
        {
            ConversationManager.nextConversation = 1;
        }
        if (GameManager.instance.isGirl && GameManager.instance.isDoor && !GameManager.instance.isBee)
        {
            ConversationManager.nextConversation = 2;
        }
        if (GameManager.instance.isGirl && GameManager.instance.isDoor && GameManager.instance.isBee)
        {
            ConversationManager.nextConversation = 3;
        }

        Debug.Log(ConversationManager.nextConversation);

        // Sử dụng các biến dưới để so sánh và chạy Animation,...
        if (ConversationManager.nextConversation == 1 && ConversationManager.currentConversationIndex >= 7) {
            animator.SetBool("IsAction", true);
        }
        if (ConversationManager.nextConversation == 1 && ConversationManager.currentConversationIndex == 9 && !actionTriggered)
        {
            ShowImageAndPlayAudio();
            Debug.Log("Current Index: " + ConversationManager.currentConversationIndex);
            actionTriggered = true;
        }
        if (ConversationManager.nextConversation == 1 && ConversationManager.currentConversationIndex >= 10) {
            animator.SetBool("IsAction", false);
        }
        if (ConversationManager.nextConversation == 2 && ConversationManager.currentConversationIndex >= 12) {
            GameManager.instance.isBee = true;
            beeFPoly.SetActive(false);
        }
        if (ConversationManager.nextConversation >= 3)
        {
            beeFPoly.SetActive(false);
        }
    }

    void Conversation() {
        // Tiến gần để nói chuyện
        if (Vector2.Distance(transform.position, player.position) < 2) {
            switch (ConversationManager.nextConversation) {
                // So sánh các điều kiện để nói chuyện với NPC tiếp theo, tránh bị trùng lặp
                case 0:
                    if (gameObject.CompareTag("Girl") && !GameManager.instance.isGirl) {
                        chatboxUI.SetActive(true);
                        GameManager.instance.isGirl = true;
                        Debug.Log(ConversationManager.currentConversationIndex);
                        ConversationManager.Instance.LoadConversation("conversation1");
                    }
                    
                    break;
                case 1:
                    if (gameObject.CompareTag("Door") && !GameManager.instance.isDoor) {
                        chatboxUI.SetActive(true);
                        GameManager.instance.isDoor = true;
                        ConversationManager.Instance.LoadConversation("conversation2");
                    }
                    break;
                case 2:
                    if (gameObject.CompareTag("BeePoly") && !GameManager.instance.isBee) {
                        chatboxUI.SetActive(true);
                        ConversationManager.Instance.LoadConversation("conversation3");
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

    private void ShowImageAndPlayAudio()
    {
        imgUI.SetActive(true); //Hiển thị hình ảnh
        audioClip.Play();//Nhạc mở
        StartCoroutine(HideImageAndStopAudio());
    }
    private IEnumerator HideImageAndStopAudio()
    {
        yield return new WaitForSeconds(1);
        imgUI.SetActive(false);
        audioClip.Stop();
    }
}
