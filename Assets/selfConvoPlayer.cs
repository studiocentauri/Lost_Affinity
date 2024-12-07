using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selfConvoPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    public TextMeshProUGUI dialogueText;
    [SerializeField]
    public string[] dialogue;
    public Texture[] speakerImage;
    public string[] speaker;
    [SerializeField]
    public float wordSpeed;
    
    public RawImage rawImage;
    public TMP_Text speakerName;

    private int index;
    public bool convoDone = false;
    public GameObject convoStartCollider;
    private bool isSelfconvo = false;
    public FadeOut fadeOut;
    public void StartDialogues()
    {
        isSelfconvo=true;
        GetComponent<playermovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponentInChildren<PlayerAnimation>().enabled = false;
        Debug.LogWarning("Dialogue Started");
        //Debug.Log(SceneManager.GetActiveScene().name);
        dialoguePanel.SetActive(true);
        Debug.Log(dialoguePanel.activeInHierarchy);
        StartCoroutine(Typing());
    }
    private void Update()
    {
        if(dialoguePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.E) && isSelfconvo)
        {
            NextLine();
        }
    }
    void ResetPlayer()
    {
        GetComponent<playermovement>().enabled = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponentInChildren<PlayerAnimation>().enabled = true;
    }
   
    public void zeroText()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        index = 0;
        if (GetComponent<AutoMoveNPCs>() != null) GetComponent<AutoMoveNPCs>().enabled = true;

        dialoguePanel.SetActive(false);

        convoDone = true;
        if (SceneManager.GetActiveScene().name == "Level-1 1") { Invoke("Level2", .5f); isSelfconvo = false; }
        if (SceneManager.GetActiveScene().name == "Ending") 
        {
            isSelfconvo = false;
            fadeOut.StartFadeOut();
            Invoke("ComingSoon", fadeOut.fadeDuration);
        }
        if (SceneManager.GetActiveScene().name == "Level-2")
        {
            if(convoStartCollider != null) Destroy(convoStartCollider);
            isSelfconvo = false;
            ResetPlayer();
        }
        else
        {
            isSelfconvo = false;
            if(convoStartCollider != null) Destroy(convoStartCollider);
            ResetPlayer();
        }
    }

    void ComingSoon()
    {
        SceneManager.LoadScene("ToBeContinued");
    }

    void Level2()
    {
        // Load level 2
        SceneManager.LoadScene("Level-2");
    }
    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            Debug.Log("Writing");
        }
        else
        {
            Debug.Log("not Writing");
            zeroText();
        }
    }

    IEnumerator Typing()
    {
        //istyping = true;
        rawImage.texture = speakerImage[index];
        speakerName.text = speaker[index];
        int i = index;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            if (i != index)
            {
                break;
            }
        }

        //istyping = false;
    }
}
