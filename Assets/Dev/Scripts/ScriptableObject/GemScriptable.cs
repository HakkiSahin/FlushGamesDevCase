using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePrefabs", menuName = "Gems")]
public class GemScriptable : ScriptableObject
{
    public List<Mines> gemList;

    [System.Serializable]
    public class Mines
    {
        public string gemName;
        public int gemValue;
        public Sprite gemSprite;
        public GameObject gemPrefabs;
        
    }
}