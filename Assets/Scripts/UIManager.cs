using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasGroup uiGroup; // Gán CanvasGroup từ Panel
    public TMP_Text displayText; // Gán Text từ UI
    public float transitionDuration = 2f; // Thời gian chuyển đổi
    public float displayDuration = 2f; // Thời gian hiển thị văn bản

    private void Start()
    {
        StartCoroutine(ShowUI());
    }

    private IEnumerator ShowUI()
    {
        // Hiện UI với màu trắng
        uiGroup.alpha = 1f;

        // Chuyển đổi dần sang màu đen
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            uiGroup.alpha = 1 - (elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiGroup.alpha = 0f; // Đặt alpha về 0 sau khi chuyển đổi

        // Hiện text đầu tiên
        displayText.text = "Text 1";
        yield return new WaitForSeconds(displayDuration);

        // Hiện text thứ hai
        displayText.text = "Text 2";
    }
}
