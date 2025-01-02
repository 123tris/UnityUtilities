using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingEffect : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Adjust the interval for blinking

    private Image image;
    private bool isBlinking = false;
    private Coroutine coroutine;

    private void OnEnable()
    {
        image = GetComponent<Image>();
        coroutine = StartCoroutine(Blink());
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);
            isBlinking = !isBlinking;
            image.enabled = isBlinking;
        }
    }
}