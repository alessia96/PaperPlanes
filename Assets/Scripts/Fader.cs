﻿using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

    public static Fader instance;



    public Texture2D fadeOutTexture;
    public float fadeSpeed;

    private int drawDepth = -1000;
    public float alpha = 1.0f;

    private int fadeDir = -1;

	private void Awake()
	{
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
	}
	void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int dir)
    {
        fadeDir = dir;
        return (fadeSpeed);
    }

    void OnEnable()
    {
        // alpha = 1;
        BeginFade(-1);
    }
}