using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{


    Animator animator;

    StarterAssetsInputs starterAssetsInputs;


    [SerializeField] WeaponSO weaponSO;

    [SerializeField] WeaponSO startingWeaponSO;


    float cooldownTime = 0;

    CinemachineVirtualCamera virtualCamera;

    [SerializeField] GameObject zoomScopeImage;

    [SerializeField] BulletManager bulletManager;

    [SerializeField] TMP_Text ammoText;

    [SerializeField] Camera weaponCamera;

    float DEFAULT_FOV;
    float DEFAULT_ROTATION_SPEED;

    FirstPersonController firstPersonController;

    Weapon weapon;


    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();


        animator = GetComponent<Animator>();

        firstPersonController = GetComponentInParent<FirstPersonController>();
        virtualCamera = FindFirstObjectByType<CinemachineVirtualCamera>();

        DEFAULT_FOV = virtualCamera.m_Lens.FieldOfView;


        DEFAULT_ROTATION_SPEED = firstPersonController.RotationSpeed;

        SwitchWeapon(startingWeaponSO);
    }

    private void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    void HandleShoot()
    {
        cooldownTime += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;

        if (!bulletManager.CanFireCurrentWeapon(weaponSO))
        {
            return;
        }

        if (cooldownTime >= weaponSO.FireRate)
        {

            animator.Play("Shoot", 0, 0f);

            weapon.FireBullet(weaponSO);

            cooldownTime = 0;

            ammoText.text = bulletManager.UpdateBulletCount(weaponSO, -1).ToString("D2");


            // TODO: check it
            // return;
        }




        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    public void SwitchWeapon(WeaponSO newWeaponSO)
    {
        GameObject currentWeapon = Instantiate(newWeaponSO.weaponPrefab, transform);

        if (weapon != null)
        {
            Destroy(weapon.gameObject);
        }


        weapon = currentWeapon.GetComponent<Weapon>();


        this.weaponSO = newWeaponSO;
        ammoText.text = bulletManager.UpdateBulletCount(weaponSO, weaponSO.LoadedBulletCount).ToString("D2");

    }

    public void IncreaseAmmo(WeaponSO weaponSO, int ammoCount)
    {

        string updatedAmmoText = bulletManager.UpdateBulletCount(weaponSO, ammoCount).ToString("D2");

        if (this.weaponSO.name == weaponSO.name)
        {
            ammoText.text = updatedAmmoText;
        }
    }
    void HandleZoom()
    {
        if (weaponSO.ZoomAllowed)
        {
            if (starterAssetsInputs.zoom)
            {
                ZoomCamera();
            }
            else
            {
                DisableCameraZoom();
            }
        }
    }

    void ZoomCamera()
    {

        zoomScopeImage.SetActive(true);
        LensSettings lensSettings = virtualCamera.m_Lens;
        lensSettings.FieldOfView = weaponSO.zoomFOV;
        weaponCamera.fieldOfView = weaponSO.zoomFOV;

        firstPersonController.ChangeRotationSpeed(weaponSO.ZoomRotationSpeed);
        virtualCamera.m_Lens = lensSettings;
    }
    void DisableCameraZoom()
    {
        firstPersonController.ChangeRotationSpeed(DEFAULT_ROTATION_SPEED);
        zoomScopeImage.SetActive(false);
        LensSettings lensSettings = virtualCamera.m_Lens;
        lensSettings.FieldOfView = DEFAULT_FOV;
        weaponCamera.fieldOfView = DEFAULT_FOV;

        virtualCamera.m_Lens = lensSettings;
    }

}
