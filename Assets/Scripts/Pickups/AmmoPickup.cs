using UnityEngine;

public class AmmoPickup : BasePickup
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] int ammoCount = 10;

    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(Collider other)
    {
        ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
        activeWeapon.IncreaseAmmo(weaponSO, ammoCount);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
