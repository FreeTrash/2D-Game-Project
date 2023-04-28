using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Shake : MonoBehaviour
{
    
    public static Shake Instance {get; private set;}
   
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float ShakeTimer;
   
    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        Instance = this;
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        ShakeTimer = time;

    }

    private void Update()
    {
        if (ShakeTimer > 0)
        {
            ShakeTimer -= Time.deltaTime;

            if (ShakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
               
    }
}
