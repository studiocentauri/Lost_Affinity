using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SafeUI : MonoBehaviour
{
    public string sceneToLoad; //uncomment the line in CheckPasscode() to load the scene
    private int combinationLength;
    public TextMeshProUGUI promptText; //to display the prompt
    public TextMeshProUGUI displayText; //to display the input passcode
    private string passcode; //actual passcode
    private string inputPasscode; //input passcode
    public Sprite[] fingerprintSprites; // Array of sprites to use as hints
    public FadeOut fadeOut;

    GameObject SafeManager;

    void Start(){
        displayText.text = "Enter Passcode";
        inputPasscode = "";
        SafeManager = FindObjectOfType<SafeManager>().gameObject;
        passcode = SafeManager.GetComponent<SafeManager>().passcode;
        combinationLength = SafeManager.GetComponent<SafeManager>().combinationLength;
        GiveHint(); // Provide hint
    }

    public void TakeInput(int digit){
        inputPasscode += digit.ToString();
        updateDisplay();
    }

    public void Delete(){
        if(inputPasscode.Length>0)
        inputPasscode = inputPasscode.Substring(0, inputPasscode.Length - 1);
        updateDisplay();
    }

    public void CheckPasscode(){
        if(inputPasscode == passcode){
            promptText.text = "Safe Unlocked!";
            promptText.gameObject.SetActive(true);
            //StartCoroutine(SceneChange());
            gameObject.SetActive(false);
            fadeOut.StartFadeOut();
            Destroy(SafeManager);
            Invoke("SceneChange", fadeOut.fadeDuration);
            // Do something to unlock the safe
            //SceneManager.LoadScene(sceneToLoad);
        }
        else{
            inputPasscode = "";
            displayText.text = "Wrong Passcode!"; //separated from updateDisplay() to cover the all deleted case
        }
        //updateDisplay();
    }

    void updateDisplay(){
        if(inputPasscode.Length > combinationLength)
            inputPasscode = inputPasscode.Substring(0, combinationLength);
        if(inputPasscode == "")
            displayText.text = "Enter Passcode";
        else{
            displayText.text = inputPasscode;
            displayText.text += new string('_', combinationLength-inputPasscode.Length);
        }
    }

    void GiveHint(){
        foreach(char ch in passcode){
            Button button = GameObject.Find("Button_" + ch).GetComponent<Button>(); // Get the button
            int index = (int)char.GetNumericValue(ch); // Convert character to integer index
            if(index >= 0 && index < fingerprintSprites.Length){
                button.GetComponent<Image>().sprite = fingerprintSprites[index]; // Set the button's image
            }
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}