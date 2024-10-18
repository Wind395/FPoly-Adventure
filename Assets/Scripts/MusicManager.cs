using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    public static MusicManager instance;  // Singleton để quản lý nhạc

    [SerializeField] AudioSource menuMusic; // Nhạc đăng nhập và menu
    [SerializeField] AudioSource gameMusic; // Nhạc màn chơi
    public AudioSource enemyMusic;// nhạc quái 
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
        }
    }

    public void PlayGameMusic()
    {
        if (!gameMusic.isPlaying)
        {
            enemyMusic.Stop(); 
            menuMusic.Stop();  // Dừng nhạc đăng nhập/menu
            gameMusic.Play();  // Phát nhạc màn chơi
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
