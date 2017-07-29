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
}
