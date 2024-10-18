using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider menuMusicSlider;
    [SerializeField] Slider gameMusicSlider;

    private void Start()
    {

        // Tải giá trị âm lượng đã lưu (nếu có) hoặc đặt mặc định
        if (PlayerPrefs.HasKey("menuMusicVolume"))
        {
            menuMusicSlider.value = PlayerPrefs.GetFloat("menuMusicVolume");
        }
        else
        {
            menuMusicSlider.value = 1;  // Giá trị mặc định
        }

        if (PlayerPrefs.HasKey("gameMusicVolume"))
        {
            gameMusicSlider.value = PlayerPrefs.GetFloat("gameMusicVolume");
        }
        else
        {
            gameMusicSlider.value = 1;  // Giá trị mặc định
        }

        // Cập nhật âm lượng ban đầu
        MusicManager.instance.SetMenuVolume(menuMusicSlider.value);
        MusicManager.instance.SetGameVolume(gameMusicSlider.value);
    }

    public void ChangeMenuMusicVolume()
    {
        float volume = menuMusicSlider.value;
        MusicManager.instance.SetMenuVolume(volume);
        PlayerPrefs.SetFloat("menuMusicVolume", volume);  // Lưu giá trị
    }

    public void ChangeGameMusicVolume()
    {
        float volume = gameMusicSlider.value;
        MusicManager.instance.SetGameVolume(volume);
        PlayerPrefs.SetFloat("gameMusicVolume", volume);  // Lưu giá trị
    }

}
