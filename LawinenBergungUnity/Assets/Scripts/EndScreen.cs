using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;

    private void Start()
    {
        helpLabel.SetText("Hilfen: " + PlayerPrefs.GetInt("Help"));
        errorLabel.SetText("Fehler: " + PlayerPrefs.GetInt("Error"));
    }

    public void GoToHome()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
