using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMenuScene()
    {
        // Khi quay về menu hoặc chuyển sang menu, tiếp tục phát nhạc menu
        MusicManager.instance.PlayMenuMusic();
        SceneManager.LoadScene("Menu");  // Tên scene menu
    }

    public void LoadGameScene()
    {
        // Khi chuyển sang màn chơi, phát nhạc màn chơi
        MusicManager.instance.PlayGameMusic();
        SceneManager.LoadScene("P203");  // Tên scene màn chơi
        SceneManager.LoadScene("Floor 1");
        SceneManager.LoadScene("Floor 2");
        SceneManager.LoadScene("Floor 3");
        SceneManager.LoadScene("Floor 4");
        SceneManager.LoadScene("Front of P");
        SceneManager.LoadScene("P202");
        SceneManager.LoadScene("P301");
        SceneManager.LoadScene("P404");
    }
    public void LoadLoginScene()
    {
        // Khi quay lại scene đăng nhập, vẫn phát nhạc menu
        MusicManager.instance.PlayMenuMusic();
        SceneManager.LoadScene("SignInUp");  // Tên scene đăng nhập
    }
}
