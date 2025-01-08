using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int DamagePoints = 40;
    float _fireRate = 0.5f;

    public GameObject HitFx;
    // public int DamagePoints { get { return _damagePoints; } }
    public float FireRate = 2f;
    public bool IsAutomatic = false;
    public bool ZoomAllowed;

    public float zoomFOV = 10f;

    public float ZoomRotationSpeed = 0.3f;

    public GameObject weaponPrefab;

    public string Name;

    public int LoadedBulletCount = 6;
    public int MaxBulletCapacity = 12;
    public AudioClip audioClip;
}
