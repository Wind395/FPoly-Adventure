using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item : MonoBehaviour, IInteractable
{
    public abstract void Interact();

    public string _itemID;
    public GameObject paperInforFloor4;
    public GameObject otherPaperInfor;
    public GameObject fButton;
    public bool pickUp = false;
    public bool isCollected;
    // Start is called before the first frame update
    void Start()
    {
        isCollected = PlayerPrefs.GetInt(_itemID, 0) == 1;
        Debug.Log(isCollected);
        if (isCollected)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
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
}
