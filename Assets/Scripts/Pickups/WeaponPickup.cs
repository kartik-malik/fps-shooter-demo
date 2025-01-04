using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickup : BasePickup
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] WeaponSO _weaponS0;

    public WeaponSO weaponSO { get { return _weaponS0; } }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    protected override void OnPickup(Collider other)
    {
        ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
        activeWeapon.SwitchWeapon(weaponSO);


    }


}
