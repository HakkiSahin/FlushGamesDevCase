using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private Button btn;

    [SerializeField] private GameObject uiPrefab;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick?.AddListener(() =>  CloseMenu());
    }

    void CloseMenu()
    {
        uiPrefab.SetActive(false);
    }
}
