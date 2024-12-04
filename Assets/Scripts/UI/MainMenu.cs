using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    public GameObject pausemenu;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level-1 1");
    }
    
    public void Settings(){
        panel2.SetActive(false);
        panel.SetActive(true);
        //volume
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Back(){
        panel.SetActive(false);
        panel2.SetActive(true);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu_Arsal");
    }
    public void Resume(){
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause(){
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
