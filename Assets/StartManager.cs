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
}
