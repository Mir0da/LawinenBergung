using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;
    [SerializeField] private TextMeshProUGUI einschätzung;

    private void Start()
    {
        helpLabel.SetText("Hilfen: " + PlayerPrefs.GetInt("Help"));
        errorLabel.SetText("Fehler: " + PlayerPrefs.GetInt("Error"));

        if (PlayerPrefs.GetInt("Error") < 1 && PlayerPrefs.GetInt("Help") == 0)
        {
            einschätzung.SetText("Perfekt! Keinen Einzigen Fehler und du hast keine Hilfe benötigt!");
        }
        else if (PlayerPrefs.GetInt("Error") < 1)
        {
            einschätzung.SetText("Sehr gut, du hast keine Fehler gemacht!");
        }
        else if (PlayerPrefs.GetInt("Error") < 3)
        {
            einschätzung.SetText("Super Leistung, fast keine Fehler! Aber es geht noch besser. ");
        }
        else
        {
            einschätzung.SetText("Den Ablauf solltest du besser nochmal üben.");
        }
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
