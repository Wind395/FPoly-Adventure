using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject stairUI;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Front of P") {
            transform.position = GameManager.lastPositionSceneFrontofP;
        }
        if (SceneManager.GetActiveScene().name == "Floor 1") {
            transform.position = GameManager.lastPositionSceneFloor1;
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
        if (other.gameObject.CompareTag("InSideP") &&  Input.GetKeyDown(KeyCode.Return)) 
        {
            GameManager.lastPositionSceneFrontofP = transform.position;
            GameManager.instance.ChangeScene("Floor 1");
        }
        if (other.gameObject.CompareTag("OutSideP") &&  Input.GetKeyDown(KeyCode.Return)) 
        {
            GameManager.lastPositionSceneFloor1 = transform.position;
            GameManager.instance.ChangeScene("Front of P");
        }
        if (other.gameObject.CompareTag("Stair") &&  Input.GetKeyDown(KeyCode.Return)) 
        {
            stairUI.SetActive(true);
        }
    }

    public void SceneStair(string name) {
        GameManager.instance.ChangeScene(name);
    }
}
