using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{
    [SerializeField] GameObject button;

    private void Start()
    {
        StartCoroutine(ShowHideButton());
    }

    IEnumerator ShowHideButton()
    {
        button.SetActive(false);
        yield return new WaitForSeconds(4f);
        button.SetActive(true);
    
    }
    //Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
