using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Glitch : MonoBehaviour
{
    public GameObject Player;
    public CinemachineVirtualCamera _cinemachineVirtualCamera;
    public float shakeIntensity = 1.0f;
    public float shakeTime = 0.5f;
    private float time = 0;

    private CinemachineBasicMultiChannelPerlin _cbmcp;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level-2")
        {
            Player.GetComponent<playermovement>().enabled = false;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.GetComponentInChildren<PlayerAnimation>().enabled = false;
            Animator anim = Player.GetComponentInChildren<Animator>();
            anim.SetBool("Glitch", true);
            Invoke("GlitchOff", 1.25f);
            Player.GetComponent<selfConvoPlayer>().StartDialogues();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playermovement>().enabled = false;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponentInChildren<PlayerAnimation>().enabled = false;
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("Glitch", true);
            ShakeCamera();
            other.GetComponent<selfConvoPlayer>().StartDialogues();
        }
    }

    void GlitchOff()
    {
        //Player.GetComponent<playermovement>().enabled = true;
        Player.GetComponentInChildren<PlayerAnimation>().enabled = true;
        Animator anim = Player.GetComponentInChildren<Animator>();
        anim.SetBool("Glitch", false);
        Destroy(gameObject);
    }
    void Level2()
    {
        // Load level 2
        SceneManager.LoadScene("Level-2");
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
            if (time <= 0)
            {
                StopShake();
            }
        }
    }

    
}
