using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Weapon/WeaponDetails", fileName = "_WeaponDetails")]
public class WeaponDetailsSO : ScriptableObject
{
    [Header("WEAPON BASE DETAILS")]
    public string weaponName;

    [Header("WEAPON OPERATING VALUES")]
    public float weaponFireRate;
    public float weaponRealoadTime;

    [Space(5)]
    public int weaponClipAmmoCapacity;
    public int weaponAmmoCapacity;
}