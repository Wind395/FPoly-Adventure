using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    // List of objects that should not be turned off
    [SerializeField] private GameObject[] exemptObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnOnOffAllLights();
        }
    }

    // Method to turn on or off all lights in the scene
    private void TurnOnOffAllLights()
    {
        // Find all Light2D components in the scene
        Light2D[] lights = FindObjectsOfType<Light2D>();

        // Toggle the enabled state of each light, except for exempt objects
        foreach (Light2D light in lights)
        {
            bool isExempt = false;
            foreach (GameObject exemptObject in exemptObjects)
            {
                if (light.gameObject == exemptObject)
                {
                    isExempt = true;
                    break;
                }
            }

            if (!isExempt)
            {
                light.enabled = !light.enabled;
            }
        }
    }
}