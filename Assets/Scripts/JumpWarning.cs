using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWarning : MonoBehaviour
{
    public GameObject Warning;

    void Start()
    {
        Warning.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Warning.SetActive(true);
            Invoke("HideWarning", 1f);
        }
    }

    void HideWarning()
    {
        Warning.SetActive(false);
    }
}
