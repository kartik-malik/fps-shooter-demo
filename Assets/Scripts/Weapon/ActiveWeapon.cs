using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{


    Animator animator;

    StarterAssetsInputs starterAssetsInputs;


    [SerializeField] WeaponSO weaponSO;

    Weapon weapon;

    float cooldownTime = 0;

    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();

        weapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        cooldownTime += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;

        if (cooldownTime < weaponSO.FireRate)
        {

            starterAssetsInputs.ShootInput(false);

            return;
        }

        animator.Play("Shoot", 0, 0f);

        weapon.FireBullet(weaponSO);
        starterAssetsInputs.ShootInput(false);
        cooldownTime = 0;

    }

}
