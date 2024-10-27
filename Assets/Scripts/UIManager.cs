using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject UI1;
    public CanvasGroup uiGroup; // Gán CanvasGroup từ Panel
    public TMP_Text displayText; // Gán Text từ UI
    public float transitionDuration = 2f; // Thời gian chuyển đổi
    public float displayDuration = 2f; // Thời gian hiển thị văn bản
    public string[] textContent;


    public GameObject UI2;
    public SpriteRenderer boySpriteRenderer;
    public Sprite boy;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "P203" && ConversationManager.nextConversation == 0) {
            StartCoroutine(OpeningShowUI());
        }
        if (SceneManager.GetActiveScene().name == "Ending" && ConversationManager.nextConversation >= 3) {
            StartCoroutine(EndingShowUI());
        }
    }

    private void Update() {
        StartCoroutine(Ending2UI());
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
        UI1.SetActive(false);
    }

    private IEnumerator Ending2UI() {
        if (ConversationManager.nextConversation == 3 && ConversationManager.currentConversationIndex == 7) {
            boySpriteRenderer.sprite = boy;
            boySpriteRenderer.flipX = false;
            yield return new WaitForSeconds(4);
            UI2.SetActive(true);
        }
    }
}
