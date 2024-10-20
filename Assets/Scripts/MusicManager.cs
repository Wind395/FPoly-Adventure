using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    
    public static MusicManager instance;  // Singleton để quản lý nhạc

    [SerializeField] AudioSource menuMusic; // Nhạc đăng nhập và menu
    [SerializeField] AudioSource gameMusic; // Nhạc màn chơi
    public AudioSource enemyMusic;// nhạc quái 

    public bool isInMenu = true;

    private void Awake()
    {
      
        // Tạo singleton để đảm bảo có một MusicManager duy nhất
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Đảm bảo MusicManager không bị hủy khi đổi scene
        }
        else
        {
            Destroy(gameObject);  // Hủy nếu đã có instance khác
        }

        StopMusic();
        ResumeGameMusic();
    }


    private void Start()
    {
        PlayMenuMusic();  // Khi khởi động game, nhạc menu phát đầu tiên
    }

    public void PlayMenuMusic()
    {
        if (!menuMusic.isPlaying)
        {
            enemyMusic.Stop();
            gameMusic.Stop();  // Dừng nhạc màn chơi (nếu đang phát)
            menuMusic.Play();  // Phát nhạc đăng nhập/menu
            isInMenu = true;
        }
    }

    public void PlayGameMusic()
    {
        if (!gameMusic.isPlaying)
        {
            enemyMusic.Stop(); 
            menuMusic.Stop();  // Dừng nhạc đăng nhập/menu
            gameMusic.Play();  // Phát nhạc màn chơi
            isInMenu = false;
        }
    }
    public void PlayenemyMusic()
    {
        Debug.Log("Quái Phát Nhạc");

        // Kiểm tra xem nhạc quái có đang phát không
        if (!enemyMusic.isPlaying) // Đổi từ gameMusic sang enemyMusic
        {
            enemyMusic.Play();
            menuMusic.Stop();
            gameMusic.Stop();
        }
        else
        {
            Debug.Log("Quái đã phát nhạc rồi!"); // Thay đổi thông điệp để rõ ràng hơn
        }
    }

    public void StopMusic()
    {
        //menuMusic.Stop();
        //gameMusic.Stop();
        enemyMusic.Stop();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Đăng ký sự kiện
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Hủy đăng ký sự kiện
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopMusic(); // Dừng nhạc quái khi scene mới được tải
        if (!isInMenu) {
            ResumeGameMusic();
        }
    }



    public void ResumeGameMusic()
    {
        if (!gameMusic.isPlaying)
        {
            gameMusic.Play();  // Phát lại nhạc game nếu chưa phát
        }
    }

    public void SetMenuVolume(float volume)
    {
        menuMusic.volume = volume;  // Điều chỉnh âm lượng nhạc đăng nhập/menu
    }

    public void SetGameVolume(float volume)
    {
        gameMusic.volume = volume;  // Điều chỉnh âm lượng nhạc màn chơi
    }

   
}
