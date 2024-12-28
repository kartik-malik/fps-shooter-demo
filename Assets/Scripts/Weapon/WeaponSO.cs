using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    private int _damagePoints = 40;
    float _fireRate = 0.5f;

    public GameObject HitFx;
    public int DamagePoints { get { return _damagePoints; } }
    public float FireRate = 2f;
}
