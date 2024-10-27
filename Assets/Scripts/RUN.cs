using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUN : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    private CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.hasRead) {
            enemy.SetActive(true);
            StartCoroutine(cameraShake.Shake(0.2f, 2f));
        }
    }
}
