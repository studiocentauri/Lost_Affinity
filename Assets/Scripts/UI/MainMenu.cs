using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    
    //bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StoryBoard");
    }
    
    public void Settings(){
        panel2.SetActive(false);
        panel.SetActive(true);
        //volume
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Back()
    {
        panel.SetActive(false);
        panel2.SetActive(true);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu_Arsal");
    }
}
