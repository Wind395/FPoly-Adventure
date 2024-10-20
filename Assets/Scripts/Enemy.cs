using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public Transform player; // Tham chiếu đến vị trí của nhân vật
    public float moveSpeed = 2f; // Tốc độ di chuyển của quái khi đuổi theo nhân vật 
    public float chaseRange = 5f; // Khoảng cách để quái bắt đầu đuổi theo nhân vật
    public float stopRange = 1f; // Khoảng cách để quái dừng lại gần nhân vật
    public float wanderSpeed = 1f; // Tốc độ lang thang
    public float leftLimit = -5f; // Giới hạn di chuyển bên trái
    public float rightLimit = 5f; // Giới hạn di chuyển bên phải

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isChasing = false; // Quái có đang đuổi theo nhân vật hay không?
    private bool movingRight = true; // Quái đang di chuyển sang phải?
   

    private bool hasPlayedEnemyMusic = false; // Biến để kiểm tra đã phát nhạc quái chưa
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // Tính khoảng cách giữa quái và nhân vật
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange && distanceToPlayer > stopRange)
        {
            // Nếu trong phạm vi đuổi, quái sẽ theo đuổi nhân vật
            isChasing = true;
            Vector2 direction = (player.position - transform.position).normalized;
            movement = direction;

            //// Kiểm tra và phát nhạc quái
            //if (MusicManager.instance != null)
            //{
            //    if (MusicManager.instance.enemyMusic != null)
            //    {
            //        Debug.Log("Đang phát nhạc quái.");
            //        MusicManager.instance.PlayenemyMusic();
            //    }
            //    else
            //    {
            //        Debug.LogError("enemyMusic không được gán trong MusicManager!");
            //    }
            //}
            //else
            //{
            //    Debug.LogError("MusicManager không tìm thấy!");
            //}
            if (!hasPlayedEnemyMusic)
            {
                if (MusicManager.instance != null)
                {
                    MusicManager.instance.PlayenemyMusic();
                    hasPlayedEnemyMusic = true; // Đánh dấu là đã phát nhạc quái
                }
            }

        }
        else if (distanceToPlayer <= stopRange)
        {
            // Nếu đã đến gần nhân vật, quái sẽ dừng lại
            movement = Vector2.zero;
        }
        else
        {
            // Nếu ngoài phạm vi đuổi, quái sẽ đi qua lại
            isChasing = false;
            Wander();

            // Nếu nhân vật ra khỏi phạm vi quái
            if (hasPlayedEnemyMusic)
            {
                MusicManager.instance.StopMusic(); 
                hasPlayedEnemyMusic = false; // Reset lại khi quái không còn đuổi theo
                MusicManager.instance.ResumeGameMusic(); // Phát lại nhạc game
            }
        }
    }

    void FixedUpdate()
    {
        // Di chuyển quái (đuổi theo hoặc lang thang)
        rb.MovePosition((Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Hàm để quái lang thang qua lại khi chưa đuổi theo nhân vật
    void Wander()
    {
        if (movingRight)
        {
            // Di chuyển sang phải
            movement = Vector2.right * wanderSpeed;

            // Nếu quái đã đạt đến giới hạn phải, đổi hướng sang trái
            if (transform.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            // Di chuyển sang trái
            movement = Vector2.left * wanderSpeed;

            // Nếu quái đã đạt đến giới hạn trái, đổi hướng sang phải
            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }
    }

    // Hiển thị phạm vi đuổi và giới hạn di chuyển  để dễ điều chỉnh
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange); // Phạm vi đuổi theo
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopRange); // Phạm vi dừng lại gần nhân vật

        // Vẽ đường di chuyển giới hạn
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(leftLimit, transform.position.y, 0), new Vector3(rightLimit, transform.position.y, 0)); // Giới hạn trái và phải
    }
}
