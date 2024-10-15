using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject highscoreUI;
    [SerializeField] private GameObject settingsUI;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(StartGame);
        buttons[1].onClick.AddListener(Highscore);
        buttons[2].onClick.AddListener(Settings);
        buttons[3].onClick.AddListener(Exit);
        buttons[4].onClick.AddListener(Logout);
        buttons[5].onClick.AddListener(BackHC);
        buttons[6].onClick.AddListener(BackST);
    }

    void StartGame() {
        GameManager.instance.ChangeScene("P203");
    }

    void Highscore() {
        menuUI.SetActive(false);
        highscoreUI.SetActive(true);
    }
    
    void Settings() {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    void Exit() {
        Application.Quit();
    }

    void Logout() {
        GameManager.instance.ChangeScene("SignInUp");
    }

    void BackHC() {
        highscoreUI.SetActive(false);
        menuUI.SetActive(true);
    }
    void BackST() {
        settingsUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
