using UnityEngine;
using TMPro;

public class ToastController : MonoBehaviour
{
    public static ToastController Instance { get; private set; }

    [Header("Refs")]
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI text;

    [Header("Timing")]
    public float showSeconds = 1.4f;
    public float fadeSeconds = 0.35f;

    float _t = 0f;
    bool _showing = false;

    void Awake()
    {

        if (!canvasGroup) canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f; // start hidden
    }

    public void Show(string msg)
    {
        if (text) text.text = msg;
        _t = 0f;
        _showing = true;
        StopAllCoroutines();
        StartCoroutine(FadeRoutine());
    }

    System.Collections.IEnumerator FadeRoutine()
    {
        // fade in
        float a = canvasGroup.alpha;
        for (float t = 0; t < fadeSeconds; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(a, 1f, t / fadeSeconds);
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // hold
        yield return new WaitForSeconds(showSeconds);

        // fade out
        for (float t = 0; t < fadeSeconds; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeSeconds);
            yield return null;
        }
        canvasGroup.alpha = 0f;
        _showing = false;
    }
}
