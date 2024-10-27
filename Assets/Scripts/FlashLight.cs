using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{

    private Light2D light2D;
    [SerializeField] private float offTime;
    [SerializeField] private float onTime;
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
        if (timeCount >= offTime) {
            light2D.enabled = false;
        }
        if (timeCount >= onTime) {
            light2D.enabled = true;
            timeCount = 0f;
        }
    }
}
