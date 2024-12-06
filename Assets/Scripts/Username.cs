using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Username : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    public void SavePlayerName()
    {
        if (nameInputField != null && !string.IsNullOrWhiteSpace(nameInputField.text))
        {
            GameManager.Instance.PlayerName = nameInputField.text;
            Debug.Log("Player Name Saved: " + GameManager.Instance.PlayerName);
            SceneManager.LoadScene("Level-1 1");
        }
        else
        {
            Debug.LogWarning("Player name is empty or invalid!");
        }
    }
}
