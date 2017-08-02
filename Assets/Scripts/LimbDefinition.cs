using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Limb", menuName = "Limb/Definition", order = 1)]
public class LimbDefinition : ScriptableObject {

    public string name;
    public string description;
    public float HP;
    public float DMG;
    public GameObject prefab;
    [Range(0.0f, 15.0f)]
    public float cooldown;
    public Sprite cardIcon;
    public Sprite cardContent;

    public string[] prefixNames;
    public string[] midNames;
    public string[] suffixNames;

    public string GetPrefix()
    {
        return prefixNames[Random.Range(0, prefixNames.Length - 1)];
    }
    public string GetMid()
    {
        return midNames[Random.Range(0, midNames.Length - 1)];
    }
    public string GetSuffix()
    {
        return suffixNames[Random.Range(0, suffixNames.Length - 1)];
    }
}
