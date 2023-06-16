using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }

        _instance = this;
    }

    public GemScriptable _gemScriptable;

    public Transform itemsParent;
    public GameObject itemsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // GetData();
    }

    public void DataButton()
    {
        itemsParent.gameObject.SetActive(true);
        GetData();
    }

    void GetData()
    {
        for (int i = itemsParent.GetChild(0).childCount - 1; i >= 0; i--)
        {
            Destroy(itemsParent.GetChild(0).GetChild(i).gameObject);
        }

        for (int i = 0; i < _gemScriptable.gemList.Count; i++)
        {
            GameObject item = Instantiate(itemsPrefab, Vector3.zero, Quaternion.identity, itemsParent.GetChild(0));
            item.GetComponent<GemItem>()
                .SetInfo(_gemScriptable.gemList[i].gemSprite, _gemScriptable.gemList[i].gemName);
        }
    }

    public void SaveCountGem(string gemName)
    {
        gemName = gemName.Split("(")[0];
        int gemCount = PlayerPrefs.GetInt(gemName);
        gemCount++;
        PlayerPrefs.SetInt(gemName, gemCount);
    }
}