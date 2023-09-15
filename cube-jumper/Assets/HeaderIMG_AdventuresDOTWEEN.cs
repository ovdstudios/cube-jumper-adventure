using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Jobs;

public class HeaderIMG_AdventuresDOTWEEN : MonoBehaviour
{
    [SerializeField] private Transform _innerShape, _outerShape;
    [SerializeField] private float _cycleLength = 1;
    [SerializeField] private float _endValue = 0.5f;
    void Start()
    {
        transform.DOMoveY(_endValue, _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }
}
