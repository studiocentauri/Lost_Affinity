using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused) {
                Resume();
            }
            else{
                Pause();
            }
        }
        
    }
    public void Pause(){
        Time.timeScale = 0f;
        panel.SetActive(true);
        isPaused = true;
    }
    public void Resume(){
        Time.timeScale = 1f;
        panel.SetActive(false);
        isPaused = false;
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu_Arsal");
        Time.timeScale = 1f;
    }

}
