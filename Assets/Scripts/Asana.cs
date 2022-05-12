using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asana : MonoBehaviour
{
    public string EnglishName;
    public string SanskritName;
    public string Category;
    public Sprite ImageSprite;

    public Asana (string englishName, string sanskritName, string category, Sprite imageSprite)
    {
        EnglishName = englishName;
        SanskritName = sanskritName;
        Category = category;
        ImageSprite = imageSprite;
    }
}
