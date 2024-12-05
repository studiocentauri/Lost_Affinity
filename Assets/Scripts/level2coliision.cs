using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2coliision : MonoBehaviour
{
    public GameObject LaserDeath;
    public GameObject CarSpawner;
    
    public float GameOverDuration=50f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            LaserDeath.SetActive(true);
            if(CarSpawner != null) CarSpawner.SetActive(false);
            RestartScene();
            //Invoke("RestartScene", GameOverDuration);
        }
    }
    void RestartScene()
    {
        StartCoroutine(restart());
    }
    IEnumerator restart(){
        yield return new WaitForSeconds(GameOverDuration);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
