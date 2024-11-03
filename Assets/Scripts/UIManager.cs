using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject UI1;
    public GameObject ED1;
    public CanvasGroup uiGroup; // Gán CanvasGroup từ Panel
    public TMP_Text displayText; // Gán Text từ UI
    public float transitionDuration = 2f; // Thời gian chuyển đổi
    public float displayDuration = 2f; // Thời gian hiển thị văn bản
    public string[] textContent;


    public GameObject UI2;
    public SpriteRenderer boySpriteRenderer;
    public Sprite boy;
    public GameObject jumpscare;
    public GameObject jumpScareUI;

    public GameObject pauseUI;
    public GameObject pauseBtn;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "P203" && ConversationManager.nextConversation == 0) {
            StartCoroutine(OpeningShowUI());
        }
        else
        {
            UI1.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Ending") {
            StartCoroutine(EndingShowUI());
        }
    }

    private void Update() {
        StartCoroutine(Ending2UI());

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private IEnumerator OpeningShowUI()
    {
        // Mặc định màu đen
        uiGroup.alpha = 1f;

        // Hiện text đầu tiên
        displayText.text = textContent[0];
        yield return new WaitForSeconds(displayDuration);
        displayText.text = textContent[1];
        yield return new WaitForSeconds(displayDuration);
        displayText.text = textContent[2];
        yield return new WaitForSeconds(displayDuration);
        displayText.text = textContent[3];
        yield return new WaitForSeconds(displayDuration);
        displayText.text = textContent[4];
        // Chuyển đổi mờ dần
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            uiGroup.alpha = 1 - (elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiGroup.alpha = 0f; // Đặt alpha về 0 sau khi chuyển đổi
        UI1.SetActive(false);
    }

    private IEnumerator EndingShowUI()
    {
        // Mặc định màu đen
        uiGroup.alpha = 1f;

        // Hiện text đầu tiên
        displayText.text = textContent[0];
        Debug.Log("Showed");
        yield return new WaitForSeconds(displayDuration);

        // Hiện text thứ hai
        displayText.text = textContent[1];
        // Chuyển đổi mờ dần
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            uiGroup.alpha = 1 - (elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiGroup.alpha = 0f; // Đặt alpha về 0 sau khi chuyển đổi
        ED1.SetActive(false);
    }

    private IEnumerator Ending2UI() {
        if (ConversationManager.nextConversation == 3 && ConversationManager.currentConversationIndex == 7) {
            boySpriteRenderer.sprite = boy;
            boySpriteRenderer.flipX = false;
            yield return new WaitForSeconds(1);
            jumpscare.SetActive(true);
            jumpScareUI.SetActive(true);
            yield return new WaitForSeconds(1);
            jumpScareUI.SetActive(false);
            UI2.SetActive(true);
        }
    }

    public void ReturntoMenu()
    {
        GameManager.instance.ChangeScene("Menu");
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        pauseBtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        pauseBtn.SetActive(true);
    }
}
