using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{

    private Light2D light2D;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= 0.5f) {
            light2D.enabled = false;
        }
        if (timeCount >= 0.7f) {
            light2D.enabled = true;
            timeCount = 0f;
        }
    }
}
