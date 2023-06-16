using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public GemScriptable gemScriptable;

    private void SaveGemScriptable()
    {
        string json = JsonUtility.ToJson(gemScriptable);

        string path = Application.persistentDataPath + "/gemScriptable.json";
        File.WriteAllText(path, json);

      
    }

    private void LoadGemScriptable()
    {
        string path = Application.persistentDataPath + "/gemScriptable.json";

        if (File.Exists(path))
        {
            string loadedJson = File.ReadAllText(path);

            GemScriptable loadedGemScriptable = ScriptableObject.CreateInstance<GemScriptable>();
            JsonUtility.FromJsonOverwrite(loadedJson, loadedGemScriptable);

         
            Debug.Log("GemScriptable loaded.");

            foreach (var mine in loadedGemScriptable.gemList)
            {
                Debug.Log("Gem Name: " + mine.gemName);
                Debug.Log("Gem Value: " + mine.gemValue);
               
            }
        }
        else
        {
            Debug.Log("GemScriptable file not found!");
        }
    }

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGemScriptable();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGemScriptable();
        }
    }
}