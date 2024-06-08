using System.Collections;
using UnityEngine;
using UnityEngine.UI; // For UI elements like ammo count display

public class UniversalWeapon : MonoBehaviour
{
    public float fireRate = 0.1f; // Rate of fire in seconds
    public float damage = 10f; // Damage per shot
    public float range = 100f; // Range of the weapon
    public Camera playerCamera; // Reference to the player's camera
    public ParticleSystem muzzleFlash; // Reference to the muzzle flash particle system
    public GameObject Prefab_muzzleFlash; // Prefab for the muzzle flash
    public GameObject impactEffect; // Impact effect prefab
    public float spreadAmount = 0.1f; // Spread amount
    public int maxAmmo = 30; // Maximum ammo capacity
    public int currentAmmo; // Current ammo count
    public float reloadTime = 2f; // Reload time in seconds
    public Text ammoDisplay; // UI Text element to display ammo count
    public Slider AmmoSlider;
    public Animator PlayerAnimator; // Animator for player animations
    public Transform MuzzPoint; // Point from where the muzzle flash originates

    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = maxAmmo; // Initialize current ammo
        UpdateAmmoDisplay(); // Update initial ammo count display
    }

    void Update()
    {
        if(AmmoSlider.value != currentAmmo)
        {
            AmmoSlider.value = currentAmmo;
        }
        if(AmmoSlider.maxValue != maxAmmo)
        {
            AmmoSlider.maxValue = maxAmmo;
        }



        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            PlayerAnimator.SetTrigger("Reload");
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            PlayerAnimator.SetTrigger("Reload");
        }
    }

    void Fire()
    {
        GameObject Muzzzz = Instantiate(Prefab_muzzleFlash, MuzzPoint);
        Destroy(Muzzzz, 0.2f);

        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        Vector3 spread = new Vector3(Random.Range(-spreadAmount, spreadAmount), Random.Range(-spreadAmount, spreadAmount), 0);
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2 + spread.x, Screen.height / 2 + spread.y, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            // Debug.Log(hit.transform.name);

            Health targetHealth = hit.transform.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }

            if (impactEffect != null)
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        currentAmmo--;
        UpdateAmmoDisplay();
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        UpdateAmmoDisplay();

        isReloading = false;
    }

    void UpdateAmmoDisplay()
    {
        if (ammoDisplay != null)
        {
            ammoDisplay.text = $"{currentAmmo} / {maxAmmo}";
        }
    }
}
