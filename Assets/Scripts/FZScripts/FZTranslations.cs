using System;
using System.Collections.Generic;
using UnityEngine;

//07.04.23

public class FZTranslations : MonoBehaviour
{
    public static List<FZText> AllTextsWithTranslations = new List<FZText>();
    public static int currentLanguageID;
    public DynamicText[] dynamicTexts;

    public static FZTranslations Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentLanguageID = FZSave.Int.Get("currentLanguageID", 0);
    }

    public void ChangeLanguage(int ID)
    {
        currentLanguageID = ID;
        FZSave.Int.Get("currentLanguageID", currentLanguageID);
        foreach (var text in AllTextsWithTranslations)
        {
            text.ChangeTextLanguage();
        }
    }

    public static string GetDynamicText(int ID)
    {
        return Instance.dynamicTexts[ID].variants[currentLanguageID];
    }

    [Serializable]
    public class DynamicText
    {
        public string[] variants;
    }
}
