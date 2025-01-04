using StarterAssets;
using UnityEngine;

using Cinemachine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] ParticleSystem muzzleFx;

    [SerializeField] Vector3 impulseVector;

    CinemachineImpulseSource cinemachineImpulseSource;

    void Start()
    {

        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }


    public void FireBullet(WeaponSO weaponSO)
    {
        muzzleFx.Play();

        RaycastHit rayHit;

        cinemachineImpulseSource.GenerateImpulseWithVelocity(impulseVector);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit, 100f))
        {
            HitEnemy(rayHit, weaponSO);

        }
    }

    private void HitEnemy(RaycastHit rayHit, WeaponSO weaponSO)
    {
        EnemyHealth enemyHealth = rayHit.collider.GetComponentInParent<EnemyHealth>();

        Instantiate(weaponSO.HitFx, rayHit.point, Quaternion.identity);

        enemyHealth?.OnHit(weaponSO.DamagePoints);
    }
}