using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

    public static Fader instance;

    public Texture2D fadeOutTexture;
    public float fadeSpeed;

    private int drawDepth = -1000;
    public float alpha;
    public float fadeDir;

	private void OnEnable()
	{
        instance = this;
        alpha = 1;
        BeginFade(-1);
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

}