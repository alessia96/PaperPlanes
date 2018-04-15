using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	
    public void StartButton()
    {
        StartCoroutine(StartGame());
    }

    public void QuitButton()
    {
        StartCoroutine(QuitGame());
    }

    public void InfoButton()
    {
        
    }

    IEnumerator StartGame()
    {
        float fade = Fader.instance.BeginFade(1);   
        yield return new WaitForSeconds(fade);

        SceneManager.LoadScene("Endless");

    }

    IEnumerator QuitGame()
    {
        float fade = Fader.instance.BeginFade(1);   
        yield return new WaitForSeconds(fade);

        Application.Quit();
    }
}
