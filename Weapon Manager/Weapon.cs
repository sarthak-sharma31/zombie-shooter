using UnityEngine;

[System.Serializable]
public class Weapon
{
    public string weaponName;
    public string weaponType;
    public Sprite weaponIcon; // Assign an icon image for each weapon
    public GameObject weaponPrefab; // 3D model prefab of the weapon
}
