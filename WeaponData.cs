using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public string weaponType;
    public Sprite weaponIcon;
    public GameObject weaponPrefab;
}
