using UnityEngine;
using System.Collections;

public class FadingTransition : MonoBehaviour {
    
    // texture that overlays the screen
    // can be black img or loading graphics img
    public Texture2D fadeTexture;
    public float fadeSpeed = 0.8f;

    // the object's draw order in hierarchy
    // low number renders last; therefore, renders on top
    private int drawDepth = -1000;

    // object's alpha value starts out opaque
    private float alphaValue = 1.0f;

    // fade in = -1; fade out = 1
    private int fadeDirection = -1;

	void OnGUI() {
        
        alphaValue += fadeDirection * fadeSpeed * Time.deltaTime;

        // clamp = forcing the alpha value to remain between 0-1
        alphaValue = Mathf.Clamp01(alphaValue);

        // force colour to remain consistent
        // alpha is dependent on alphaValue
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alphaValue);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public float BeginFade(int direction) {
        fadeDirection = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded() {
        // alphaValue = 1; fade in
        BeginFade(-1);
    }
}
