using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
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
        if(pickUp == true && gameObject.tag == "beeBadge" && Input.GetKeyDown(KeyCode.F)){
            GameManager.instance.CollectBeeBadge();
            Destroy(this.gameObject);
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
