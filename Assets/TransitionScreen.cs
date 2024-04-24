using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private Image image;
    private float targetAlpha = 0.0f;

    public float FadeRate = 1.0f;

    void Start()
    {
        startFadeOut();
    }

    public void startFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void startFadeOut()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        targetAlpha = 1.0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        targetAlpha = 0.0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }
}
