using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class TextGlowOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI textMeshPro;
    private float targetGlowPower = 1f;
    private float currentGlowPower = 0f;
    [SerializeField]private float transitionDuration = .5f; // Adjust this value for the duration of the transition.
    private Coroutine glowCoroutine;
    private Material textMaterial; // Cache the material.

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Cache the material to avoid stuttering on first access.
        textMaterial = textMeshPro.materialForRendering;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (glowCoroutine != null)
        {
            StopCoroutine(glowCoroutine);
        }

        glowCoroutine = StartCoroutine(ChangeGlowPowerOverTime(targetGlowPower, transitionDuration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (glowCoroutine != null)
        {
            StopCoroutine(glowCoroutine);
        }

        glowCoroutine = StartCoroutine(ChangeGlowPowerOverTime(0f, transitionDuration));
    }

    private IEnumerator ChangeGlowPowerOverTime(float targetValue, float duration)
    {
        float elapsedTime = 0f;
        float startValue = currentGlowPower;

        while (elapsedTime < duration)
        {
            currentGlowPower = Mathf.Lerp(startValue, targetValue, elapsedTime / duration);
            textMaterial.SetFloat(ShaderUtilities.ID_GlowPower, currentGlowPower);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentGlowPower = targetValue;
        textMaterial.SetFloat(ShaderUtilities.ID_GlowPower, currentGlowPower);
    }
}
