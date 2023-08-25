using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Ammo weaponAmmo;
    [SerializeField] private WeaponDetailsSO weaponDetails;

    [Header("TRANSFORM COMPONENT")]
    [SerializeField] private Transform shootPosition;

    public Ammo GetWeaponAmmo()
    {
        return weaponAmmo;
    }

    public WeaponDetailsSO GetWeaponDetails()
    {
        return weaponDetails;
    }

    public Transform GetWeaponShootPosition()
    {
        return shootPosition;
    }
}