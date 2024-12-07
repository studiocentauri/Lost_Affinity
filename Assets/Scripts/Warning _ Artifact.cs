using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Artifact : MonoBehaviour
{
    public GameObject Warning;

    void Start()
    {
        Warning.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            Warning.SetActive(true);
            Invoke("HideWarning", 3f);
        }
    }

    void HideWarning()
    {
        Warning.SetActive(false);
    }
}
