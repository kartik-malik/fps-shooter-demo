using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    int _pistolCount = 0;
    int _machineGunCount = 0;
    int _sniperCount = 0;


    const string PISTOL_WEAPON_SO_NAME = "Pistol";
    const string MACHINE_GUN_WEAPON_SO_NAME = "MachineGun";
    const string SNIPER_WEAPON_SO_NAME = "Sniper";


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CanFireCurrentWeapon(WeaponSO weaponSO)
    {

        switch (weaponSO.name)
        {
            case PISTOL_WEAPON_SO_NAME:
                return _pistolCount > 0;
            case MACHINE_GUN_WEAPON_SO_NAME:
                return _machineGunCount > 0;
            case SNIPER_WEAPON_SO_NAME:
                return _sniperCount > 0;
            default:
                return false;
        }
    }


    public int UpdateBulletCount(WeaponSO weaponSO, int value)
    {
        switch (weaponSO.name)
        {
            case PISTOL_WEAPON_SO_NAME:
                return _pistolCount = Mathf.Clamp(_pistolCount + value, 0, weaponSO.MaxBulletCapacity);
            case MACHINE_GUN_WEAPON_SO_NAME:
                return _machineGunCount = Mathf.Clamp(_machineGunCount + value, 0, weaponSO.MaxBulletCapacity);
            case SNIPER_WEAPON_SO_NAME:
                return _sniperCount = Mathf.Clamp(_sniperCount + value, 0, weaponSO.MaxBulletCapacity);

            default:
                return 0;
        }
    }


    public int GetWeaponCount(WeaponSO weaponSO)
    {
        switch (weaponSO.name)
        {
            case PISTOL_WEAPON_SO_NAME:
                return _pistolCount;
            case MACHINE_GUN_WEAPON_SO_NAME:
                return _machineGunCount;
            case SNIPER_WEAPON_SO_NAME:
                return _sniperCount;
            default:
                return 0;
        }
    }


}
