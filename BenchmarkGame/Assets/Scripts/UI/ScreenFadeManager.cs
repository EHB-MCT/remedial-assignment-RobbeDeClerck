using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFadeManager : MonoBehaviour
{
    public Image fadeImage; // Fullscreen UI Image (black)
    public float fadeDuration = 1f;
    public bool autoFadeInOnStart = true;

    private Coroutine fadeRoutine;

    private void Awake()
    {
        if (fadeImage == null)
        {
            Debug.LogError("ScreenFadeManager: No fade image assigned!");
            enabled = false;
        }
    }

    private void Start()
    {
        if (autoFadeInOnStart)
        {
            Color c = fadeImage.color;
            c.a = 1f;
            fadeImage.color = c;
            fadeImage.raycastTarget = true;

            FadeIn();
        }
    }

    public void FadeIn(System.Action onComplete = null)
    {
        StartFade(1f, 0f, onComplete); // Black → Clear
    }

    public void FadeOut(System.Action onComplete = null)
    {
        StartFade(0f, 1f, onComplete); // Clear → Black
    }

    private void StartFade(float fromAlpha, float toAlpha, System.Action onComplete)
    {
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeRoutine(fromAlpha, toAlpha, onComplete));
    }

    private IEnumerator FadeRoutine(float startAlpha, float endAlpha, System.Action onComplete)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;
        color.a = startAlpha;
        fadeImage.color = color;
        fadeImage.raycastTarget = true;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = color;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;
        fadeImage.raycastTarget = endAlpha > 0f;

        onComplete?.Invoke();
    }
}
