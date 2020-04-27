using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "newObjectData", menuName = "ObjectData", order = 51)]
public class Settings : ScriptableObject
{
    [SerializeField]
    private string objectName;
    [SerializeField]
    private GameObject mesh;
    [SerializeField]
    private ColorSetting[] ColorSettings;
    public string getName()
    {
        return objectName;
    }
    public Color GetRandomColor()
    {
        return ColorSettings[UnityEngine.Random.Range(0, ColorSettings.Length)].colors;
    }
    public Color GetColor(uint clicks)
    {
        for(int i = ColorSettings.Length-1; i >= 0; i--)
        {
            if(ColorSettings[i].clicksForColor < clicks)
            {
                return ColorSettings[i].colors;
            }
        } 
        return ColorSettings[0].colors;
        
    }
    public GameObject GetMesh()
    {
        return mesh;
    }
}
[Serializable]
public struct ColorSetting
{
    [SerializeField]
    public Color colors;
    [SerializeField]
    public uint clicksForColor;
};

