using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipBtn : MonoBehaviour
{
    private WeaponManager weaponManager;

    void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
    }
    
    public void OnButtonClick(){
        weaponManager.EquipClicked();
    }

}
