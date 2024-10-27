using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{

    [SerializeField] private GameObject paperInforFloor4;
    [SerializeField] private GameObject otherPaperInfor;
    [SerializeField] private GameObject fButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUp == true && gameObject.tag == "Paper" && Input.GetKeyDown(KeyCode.F)){
            GameManager.instance.CollectPapers();
            Destroy(this.gameObject);
        }
        if(pickUp == true && gameObject.tag == "Golden Bee" && Input.GetKeyDown(KeyCode.F)){
            GameManager.instance.CollectBeeBadge();
            Destroy(this.gameObject);
        }
        if (pickUp == true && gameObject.tag == "Information Active" &&  Input.GetKeyDown(KeyCode.F)) {
            paperInforFloor4.SetActive(true);
            GameManager.instance.canRun = false;
            GameManager.instance.hasRead = true;
        }
        if (pickUp == true && gameObject.tag == "Information" &&  Input.GetKeyDown(KeyCode.F)) {
            otherPaperInfor.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
    private bool pickUp = false;
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
}
