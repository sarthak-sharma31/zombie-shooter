using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    private Vector3[] initialPositions;

    private void Start()
    {
        // Store initial positions
        initialPositions = new Vector3[weapons.Length];
        for (int i = 0; i < weapons.Length; i++)
        {
            initialPositions[i] = weapons[i].transform.position;
        }
    }

    // Method to activate a weapon and deactivate others
    public void SelectWeapon(int weaponIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == weaponIndex)
            {
                weapons[i].SetActive(true);
                weapons[i].transform.position = initialPositions[i]; // Reset position
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }

    // Method to get weapon data
    public GameObject GetWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weapons.Length)
        {
            return weapons[weaponIndex];
        }
        return null;
    }
}
