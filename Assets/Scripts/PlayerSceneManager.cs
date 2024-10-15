using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject stairUI;

    [SerializeField] private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Front of P") {
            transform.position = GameManager.lastPositionSceneFrontofP;
        }
        if (SceneManager.GetActiveScene().name == "Floor 1") {
            transform.position = GameManager.lastPositionSceneFloor1;
        }
        if (SceneManager.GetActiveScene().name == "Floor 2") {
            transform.position = GameManager.lastPositionSceneFloor2;
        }
        if (SceneManager.GetActiveScene().name == "Floor 3") {
            transform.position = GameManager.lastPositionSceneFloor3;
        }
        if (SceneManager.GetActiveScene().name == "Floor 4") {
            transform.position = GameManager.lastPositionSceneFloor4;
        }
        if (SceneManager.GetActiveScene().name == "P203") {
            transform.position = GameManager.lastPositionSceneP203;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            stairUI.SetActive(false);
        }



    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("InSideP") && Input.GetKeyDown(KeyCode.Return) && IsMoving()) 
        {
            Debug.Log("Changed");
            GameManager.lastPositionSceneFrontofP = transform.position;
            GameManager.instance.ChangeScene("Floor 1");
        }
        if (other.gameObject.CompareTag("OutSideP") && Input.GetKeyDown(KeyCode.Return)  && IsMoving()) 

        {
            Debug.Log("Changed");
            GameManager.lastPositionSceneFloor1 = transform.position;
            GameManager.instance.ChangeScene("Front of P");
        }
        if (other.gameObject.CompareTag("P203") && Input.GetKeyDown(KeyCode.Return)  && IsMoving()) {
            GameManager.lastPositionSceneFloor2 = transform.position;
            GameManager.instance.ChangeScene("P203");
        }
        if (other.gameObject.CompareTag("P202") && Input.GetKeyDown(KeyCode.Return)  && IsMoving()) {
            GameManager.lastPositionSceneFloor2 = transform.position;
            GameManager.instance.ChangeScene("P202");
        }
        if (other.gameObject.CompareTag("P301") && Input.GetKeyDown(KeyCode.Return)  && IsMoving()) {
            GameManager.lastPositionSceneFloor3 = transform.position;
            GameManager.instance.ChangeScene("P301");
        }
        if (other.gameObject.CompareTag("P404") && Input.GetKeyDown(KeyCode.Return)  && IsMoving()) {
            GameManager.lastPositionSceneFloor4 = transform.position;
            GameManager.instance.ChangeScene("P404");
        }
        if (other.gameObject.CompareTag("Lobby") && Input.GetKeyDown(KeyCode.Return)  && IsMoving()) {
            GameManager.lastPositionSceneP203 = transform.position;
            GameManager.instance.ChangeScene("Floor 2");
        }
        if (other.gameObject.CompareTag("Stair") && Input.GetKeyDown(KeyCode.Return)  && IsMoving()) 

        {
            stairUI.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    public void OnButtonClick(int index) {
        if (index == 1) {
            GameManager.lastPositionSceneFloor1 = transform.position;
            GameManager.instance.ChangeScene("Floor 1");
        }
        if (index == 2) {
            GameManager.lastPositionSceneFloor2 = transform.position;
            GameManager.instance.ChangeScene("Floor 2");
        }
        if (index == 3) {
            GameManager.lastPositionSceneFloor3 = transform.position;
            GameManager.instance.ChangeScene("Floor 3");
        }
        if (index == 4) {
            GameManager.lastPositionSceneFloor4 = transform.position;
            GameManager.instance.ChangeScene("Floor 4");
        }
    }

    private bool IsMoving() {
    return Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0;
}
}
