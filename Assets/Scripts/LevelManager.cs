using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string sceneName;

    public static System.Action loadNextScene;

	private void OnEnable()
	{
        loadNextScene += LoadNextScene;
	}

	private void OnDisable()
	{
        loadNextScene -= LoadNextScene;
	}

    void LoadNextScene()
    {
        
    }

    IEnumerator LoadFirstThenPlay()
    {
        yield return null;
    }

}
