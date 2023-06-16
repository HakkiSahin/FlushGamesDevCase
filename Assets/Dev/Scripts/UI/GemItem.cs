using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GemItem : MonoBehaviour
{
    [SerializeField] private Image gemImage;
    [SerializeField] private TextMeshProUGUI gemNameText;
    [SerializeField] private TextMeshProUGUI gemCount;


    public void SetInfo(Sprite gemIcon, string gemName)
    {
        gemNameText.text = gemName;
        gemImage.sprite = gemIcon;
        SetCount();
    }

    public void SetCount()
    {
        gemCount.text = PlayerPrefs.GetInt(gemNameText.text).ToString();
    }
}