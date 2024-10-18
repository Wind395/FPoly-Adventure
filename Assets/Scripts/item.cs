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
        if(pickUp == true && Input.GetKeyDown(KeyCode.F)){
            GameManager.instance.CollectPapers();
            Debug.Log(GameManager.instance.paper);
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
