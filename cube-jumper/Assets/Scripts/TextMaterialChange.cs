using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class TextGlowOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI textMeshPro;
    private float targetGlowPower = 1f;
    private float currentGlowPower = 0f;
    [SerializeField]private float transitionDuration = .5f;
    public Coroutine glowCoroutine;
    private Material textMaterial; 

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        
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
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        currentGlowPower = targetValue;
        textMaterial.SetFloat(ShaderUtilities.ID_GlowPower, currentGlowPower);
    }
    //the object is disabled some way rather than destroyed when you press play.
    //Disabled objects stop all coroutines, so it doesn't finish its fade thing. You should probably 
    //have an OnDisable that instantly resets the glow back to normal with no timer
    private void OnDisable()
    {
        if(glowCoroutine != null)
        {
            StopCoroutine(glowCoroutine );

            currentGlowPower = 0f;
            textMaterial.SetFloat(ShaderUtilities.ID_GlowPower, currentGlowPower);
        }
    }
}
