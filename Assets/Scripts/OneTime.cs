using UnityEngine;
using UnityEngine.UI;

public class OneTime : MonoBehaviour
{
    public GameObject Artifact1;
    public GameObject text;
    public GameObject useText;

    void Start()
    {
        text.SetActive(false);
        useText.SetActive(false);
    }
    void Update()
    {
        if(Artifact1.activeSelf == false)
        {
            text.SetActive(true);
        }
        if(text.activeSelf == true && Input.GetKeyDown("1"))
        {
            text.SetActive(false);
            useText.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
