using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private LayerMask raycastLayerMask;

    private float fireRateCooldownTimer;

    private Camera cameraCache;

    private Transform weaponShootTransform;

    private void Awake()
    {
        cameraCache = Camera.main;
    }

    private void Start()
    {
        weaponShootTransform = currentWeapon.GetWeaponShootPosition();
    }

    private void Update()
    {
        fireRateCooldownTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void Shoot()
    {
        Ray shootingRay = new Ray(cameraCache.transform.position, cameraCache.transform.forward);
        RaycastHit raycastHit;

        if (Physics.Raycast(shootingRay, out raycastHit, 
            float.PositiveInfinity, raycastLayerMask))
        {
            if (InputManager.Instance.IsFireButtonPressed() && IsWeaponReadyToShoot())
            {
                ResetFireRateCooldownTimer();

                Ammo bullet = Instantiate(currentWeapon.GetWeaponAmmo());
                bullet.Initialize(weaponShootTransform.position, 
                    raycastHit.point);
            }
        }
    }

    public bool IsWeaponReadyToShoot()
    {
        if (fireRateCooldownTimer >= 0)
        {
            return false;
        }

        return true;
    }

    private void ResetFireRateCooldownTimer()
    {
        fireRateCooldownTimer = currentWeapon.GetWeaponDetails().weaponFireRate;
    }
}