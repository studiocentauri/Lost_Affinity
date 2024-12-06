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
        if(Input.GetKeyDown(KeyCode.Alpha1))
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
