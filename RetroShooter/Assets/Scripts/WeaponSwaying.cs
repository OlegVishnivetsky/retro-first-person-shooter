using UnityEngine;

public class WeaponSwaying : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform weaponHolderTransform;

    [Header("SWAY PARAMETERS")]
    [SerializeField] private float smoothness;
    [SerializeField] private float swayMultiplier;

    private void Update()
    {
        SwayWeapon();
    }

    private void SwayWeapon()
    {
        Vector2 mouseDelta = inputManager.GetMouseDelta() * swayMultiplier;

        Quaternion yRotation = Quaternion.AngleAxis(-mouseDelta.y, Vector3.right);
        Quaternion xRotation = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);

        Quaternion targetRotation = yRotation * xRotation;

        weaponHolderTransform.localRotation =
            Quaternion.Slerp(weaponHolderTransform.localRotation, targetRotation, smoothness * Time.deltaTime);
    }
}