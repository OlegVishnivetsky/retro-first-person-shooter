using UnityEngine;

public class Ammo : MonoBehaviour, IFireable
{
    [SerializeField] private AmmoDetailsSO ammoDetails;

    private Vector3 shootDirection;

    public void Initialize(Vector3 weaponShootPosition, Vector3 targetPosition)
    {
        transform.position = weaponShootPosition;
        shootDirection = (targetPosition - weaponShootPosition).normalized;
    }

    private void Update()
    {
        transform.position += shootDirection * Time.deltaTime * ammoDetails.ammoSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
