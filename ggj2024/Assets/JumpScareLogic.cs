using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScareLogic : MonoBehaviour
{
    public RawImage image;
    public AudioSource audiofile;
    public float fadeDuration = 1.5f;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponentInChildren<RawImage>();
        audiofile = GetComponentInChildren<AudioSource>();
    }
    public void load(Texture2D e, AudioClip a){
        image.texture = e;
        audiofile.clip = a;
        audiofile.Play();
        FitToViewport();
        StartCoroutine(FadeOut());
    }
    void FitToViewport()
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.sizeDelta = Vector2.zero;

        CanvasScaler canvasScaler = image.canvas.GetComponent<CanvasScaler>();

        float canvasScaleFactor = canvasScaler.scaleFactor;
        float viewportWidth = Screen.width / canvasScaleFactor;
        float viewportHeight = Screen.height / canvasScaleFactor;

        float imageAspect = image.texture.width / (float)image.texture.height;
        float viewportAspect = viewportWidth / viewportHeight;

        if (imageAspect > viewportAspect)
        {
            rectTransform.sizeDelta = new Vector2(viewportWidth, viewportWidth / imageAspect);
        }
        else
        {
            rectTransform.sizeDelta = new Vector2(viewportHeight * imageAspect, viewportHeight);
        }
    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1);
        audiofile.Play();
        float elapsedTime = 0f;
        Color originalColor = image.color;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
