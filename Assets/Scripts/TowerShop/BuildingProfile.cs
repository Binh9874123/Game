using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/Profile")]
public class BuildingProfile : ScriptableObject
{
    public GameObject Building;
    public string Name;
    public short Price;
    public Sprite Icon;
}
