using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class NotificationVisibility : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private float fadeDuration = 0.5f;

    private TextMeshProUGUI _tmp;

    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        yield return new WaitForSeconds(lifeTime);

        Color originalColor = _tmp.color;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            _tmp.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - (elapsed / fadeDuration));
            yield return null;
        }

        Destroy(gameObject);
    }
}
