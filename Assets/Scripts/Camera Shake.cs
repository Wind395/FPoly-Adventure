using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0; // Ensure shake is off at start
    }

    public IEnumerator Shake(float duration, float intensity)
    {
        noise.m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
    }
}
