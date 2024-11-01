using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class item : MonoBehaviour
{
    [SerializeField] private string _itemID;
    [SerializeField] private GameObject paperInforFloor4;
    [SerializeField] private GameObject otherPaperInfor;
    [SerializeField] private GameObject fButton;
    private bool pickUp = false;
    private bool isCollected;
    // Start is called before the first frame update
    void Start()
    {
        isCollected = PlayerPrefs.GetInt(_itemID, 0) == 1;
        if (isCollected)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUp == true && gameObject.tag == "Paper" && Input.GetKeyDown(KeyCode.F)){
            GameManager.instance.CollectPapers();
            Collect();
        }
        if(pickUp == true && gameObject.tag == "Golden Bee" && Input.GetKeyDown(KeyCode.F)){
            GameManager.instance.CollectBeeBadge();
            Collect();
        }
        if (pickUp == true && gameObject.tag == "Information Active" &&  Input.GetKeyDown(KeyCode.F)) {
            paperInforFloor4.SetActive(true);
            GameManager.instance.canRun = false;
            GameManager.instance.hasRead = true;
        }
        if (pickUp == true && gameObject.tag == "Information" &&  Input.GetKeyDown(KeyCode.F)) {
            otherPaperInfor.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (gameObject.tag == "Information Active") {
                paperInforFloor4.SetActive(false);
                GameManager.instance.canRun = true;
                Debug.Log(GameManager.instance.canRun);
            }
            if (gameObject.tag == "Information") {
                otherPaperInfor.SetActive(false);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            pickUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            pickUp = false;
        }
    }
    private void Collect()
    {
        // Đặt trạng thái đã nhặt và lưu vào PlayerPrefs
        isCollected = true;
        PlayerPrefs.SetInt(_itemID, 1);
        PlayerPrefs.Save();

        // Ẩn vật phẩm sau khi nhặt
        gameObject.SetActive(false);
    }
}
