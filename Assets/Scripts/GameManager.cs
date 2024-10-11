using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Vector3 lastPositionSceneFrontofP;
    public static Vector3 lastPositionSceneFloor1;
    public static Vector3 lastPositionSceneFloor2;
    public static Vector3 lastPositionSceneFloor3;
    public static Vector3 lastPositionSceneFloor4;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string nameScene) {
        SceneManager.LoadScene(nameScene);
    }
}
