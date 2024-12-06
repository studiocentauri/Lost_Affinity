using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameendlevel3 : MonoBehaviour
{
    public GameObject poison;
    public Animator helmet;
    public float helmetOpenTime = 7f;
    public float helmetOpenDuration = 0f;
    public bool inTrigger = false;
    public float t=2f;

    // Start is called before the first frame update
    void Start()
    {
        poison.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(helmet.GetBool("Helmet") == true)
        {
            helmetOpenDuration = 0f;
        }
        else if(helmet.GetBool("Helmet") == false && inTrigger == true)
        {
            helmetOpenDuration += Time.deltaTime;
            if(helmetOpenDuration >= helmetOpenTime)
            {
                helmetOpenTime -= Time.deltaTime*2;
                poison.SetActive(true);
                if(helmetOpenTime <= 0)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level3 New");
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inTrigger = true;

        }
    }
    public void Activate()
    {
        Time.timeScale = 0f;
        
        poison.SetActive(true);
        Debug.Log(helmetOpenDuration);
        helmetOpenDuration -= Time.deltaTime;
        if(helmetOpenDuration <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level3 New");
        }
    }
}
