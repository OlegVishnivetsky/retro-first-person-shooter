using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Weapon/AmmoDetails", fileName = "_AmmoDetails")]
public class AmmoDetailsSO : ScriptableObject
{
    [Header("AMMO BASE PARAMETERS")]
    public float ammoDamage;
    public float ammoSpeed;
}