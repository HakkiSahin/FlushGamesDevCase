using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gem : MonoBehaviour
{
    public Tween _tween;
    public int gemValue;

    void Start()
    {
        transform.localScale = Vector3.zero;
        Grow();
    }

    void Grow()
    {
        _tween = transform.DOScale(Vector3.one, 5f).OnKill(() => { });
    }

    public void Colleted()
    {
        _tween.Pause();
        gemValue += (int)(transform.localScale.x * 200);
    }
}