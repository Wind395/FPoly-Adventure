using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.ComponentModel;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Các Scene cần Load lại khi chuyển Scene
    public static Vector3 lastPositionSceneFrontofP;
    public static Vector3 lastPositionSceneFloor1;
    public static Vector3 lastPositionSceneFloor2;
    public static Vector3 lastPositionSceneFloor3;
    public static Vector3 lastPositionSceneFloor4;
    public static Vector3 lastPositionSceneP203;
    //--------------------------------

    // Lấy Tên nhân vật từ phần đăng nhập để lưu điểm
    public static string getUsername;

    // Các biến để lưu điểm

    public int paper = 0;
    public int beeBadge = 0;

    //Timer & Score
    private float timeCounter;
    private bool isCounting = false;
    private float lastTime;
    //-------

    // Kích hoại sau khi nói chuyện với NPC để không bị trùng lặp
    public bool isGirl = false;
    public bool isDoor = false;
    public bool isBee = false;

    [SerializeField] private GameObject[] papers;
    [SerializeField] private GameObject[] bees;

    [SerializeField] private GameObject girl;
    [SerializeField] private GameObject tablechair;
    [SerializeField] private GameObject beeFPoly;

    private void Awake() {
        // Singleton
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this);
        }


        // So sánh điều kiện để sinh ra các Paper khi kích hoạt scene chỉ định
        if (ConversationManager.nextConversation >= 2) {
            if (SceneManager.GetActiveScene().name == "P203") {
                Instantiate(papers[0], new Vector2(1.7f, 0.5f), Quaternion.identity);
                girl.SetActive(false);
                beeFPoly.SetActive(true);
                tablechair.SetActive(true);
            }
            if (SceneManager.GetActiveScene().name == "P202") {
                Instantiate(papers[1], new Vector2(13.7f, 0f), Quaternion.identity);
            }
            if (SceneManager.GetActiveScene().name == "P301") {
                Instantiate(papers[2], new Vector2(1.6f, 0.5f), Quaternion.identity);
            }
            if (SceneManager.GetActiveScene().name == "P404") {
                Instantiate(papers[3], new Vector2(8.45f, 0.55f), Quaternion.identity);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCounting == true){ //đếm thời gian theo giây
            timeCounter += Time.deltaTime;
            lastTime = timeCounter;
        }
    }

    // Chức năng chuyển Scene để tái sử dụng nhiều lần
    public void ChangeScene(string nameScene) {
        SceneManager.LoadScene(nameScene);
    }

    public void CollectPapers() {
        paper++;
    }

    public void CollectBeeBadge() {
        beeBadge++;
    }


    public void IsCountingSwitcher(){   //bật/tắt bộ đếm giờ
        if(isCounting == false){
            isCounting = true;
        }else{
            isCounting = false;
        }
    }

    public void Score(){
        float score = 1000; //điểm ban đầu khi end game
        if(lastTime >= 900){    //nếu lâu hơn thì trừ bớt điểm
            score -= Mathf.Floor((lastTime - 900)*2);
        }else{                  //nếu nhanh hơn thì cộng điểm
            score += Mathf.Floor((900 - lastTime)*2);
        }
        score += beeBadge * 200; //sau đó cộng điểm ong
        if (score <= 0) {             //giới hạn ko cho điểm âm
            score = 0;
        }
    }
}
