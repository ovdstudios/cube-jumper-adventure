using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class HoverColor : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] Color _wantedColor;
    private Color _originalColor;
    private ColorBlock _cb;
    
    public Material material;
    
    private LocalKeyword glowOn;

    // Start is called before the first frame update
    void Start()
    {
       _cb = _button.colors;
       _originalColor = _cb.selectedColor;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWhenHover()
    {
        EnableGlow();
        _cb.selectedColor = _wantedColor;
        _button.colors = _cb;
    }

    public void ChangeWhenLeaves()
    {    DisableGlow();
        _cb.selectedColor = _originalColor;
        _button.colors = _cb;
    }

    public void EnableGlow()
    {   
        material.EnableKeyword(glowOn);
    }

    public void DisableGlow()
    {
        material.DisableKeyword(glowOn);        
    }
}
