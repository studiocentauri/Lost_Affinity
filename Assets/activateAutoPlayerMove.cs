using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Threading;

public class activateAutoPlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryManager inventoryManager;
    public CinemachineVirtualCamera _cinemachineVirtualCamera;
    public float shakeIntensity = 1.0f;
    public float shakeTime = 0.5f;
    private float time = 0;

    private CinemachineBasicMultiChannelPerlin _cbmcp;
    public FadeOut fadeout;
    public bool CanEnd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(inventoryManager.redSlot != null && inventoryManager.blueSlot != null && inventoryManager.greenSlot != null)
        {
            ShakeCamera();
            AutoMovePlayerOnEnd _autoMovePlayerOnEnd = collision.gameObject.GetComponent<AutoMovePlayerOnEnd>();
            _autoMovePlayerOnEnd.enabled = true;
            
            fadeout.StartFadeOut();
            CanEnd = true;
            /*ControlAutoMoveAnimation controlAutoMoveAnimation = collision.gameObject.GetComponent<ControlAutoMoveAnimation>();
            controlAutoMoveAnimation.enabled = true;*/
        }
    }
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = shakeIntensity;
        _cbmcp.m_FrequencyGain = shakeIntensity;
        Debug.Log("shake");
        time = shakeTime;

    }
    public void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0;
        _cbmcp.m_FrequencyGain = 0;
        time = 0;
    }
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                StopShake();
            }
        }
    }

}
