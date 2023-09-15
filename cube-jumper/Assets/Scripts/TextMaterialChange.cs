using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TextMaterialChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

[SerializeField] private Material hoverMaterial;
    [SerializeField] private Material originalMaterial;
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        originalMaterial = textMeshPro.fontMaterial;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        textMeshPro.fontMaterial = hoverMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        textMeshPro.fontMaterial = originalMaterial;
    }

}