using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpWarning : MonoBehaviour
{
    public GameObject Warning;
    public GameObject hintf;
    public GameObject hint2;
    int c = 0;
    void Start()
    {
        Warning.SetActive(false);
        hintf.SetActive(false);
        hint2.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Warning.SetActive(true);
            Invoke("HideWarning", 1f);
        }
        if(Input.GetKeyDown("2"))
        {
            hintf.SetActive(true);
            hint2.SetActive(false);
            Invoke("HideHintf", 5f);
        }
        if(GameObject.Find("Artifact2") == null && hintf.activeSelf == false && c == 0)
        {
            c++;
            hint2.SetActive(true);
        }
    }

    void HideWarning()
    {
        Warning.SetActive(false);
    }
    void HideHintf()
    {
        hintf.SetActive(false);
    }
    
}
