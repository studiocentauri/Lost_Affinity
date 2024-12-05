using UnityEngine;
using UnityEngine.UI;

public class OneTime : MonoBehaviour
{
    public GameObject Artifact1;
    Text text;
    public GameObject useText;

    void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }
    void Update()
    {
        if(Artifact1.activeSelf == false)
        {
            text.enabled = true;
        }
        if(text.enabled == true && Input.GetKeyDown("1"))
        {
            gameObject.SetActive(false);
            useText.SetActive(true);
        }
    }
}
