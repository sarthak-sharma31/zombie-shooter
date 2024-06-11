using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WBtns : MonoBehaviour
{
    public Image WeaponImage;
    public int weaponIndex;
    private WeaponManager weaponManager;
    public string Type;
    public string Name;
    public string Rarity;
    public TextMeshProUGUI TypeText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI RarityText;

    // Weapon Attributis--------------
    public string Damage;
    public string Range;
    public string RateOfFire;
    public string ReloadTime;
    public string AmmoAmt;
    public TextMeshProUGUI DamageTxt;
    public TextMeshProUGUI RangeTxt;
    public TextMeshProUGUI RateOFTxt;
    public TextMeshProUGUI ReloadTimeTxt;
    public TextMeshProUGUI AmmoCountTxt;

    void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        weaponManager.SelectWeapon(weaponIndex);
        TypeText.text = Type;
        NameText.text = Name;
        RarityText.text = Rarity;
        ChangeAttributes();
    }

    public void ChangeAttributes()
    {
        DamageTxt.text = Damage;
        RangeTxt.text = Range;
        RateOFTxt.text = RateOfFire;
        ReloadTimeTxt.text = ReloadTime;
        AmmoCountTxt.text = AmmoAmt;
    }
}
