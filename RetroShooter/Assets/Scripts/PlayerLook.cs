using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("MAIN PARAMETERS")]
    [SerializeField] private float verticalSensetivity = 60f;
    [SerializeField] private float horizontalSensetivity = 60f;

    [Space(5), SerializeField] private float minVerticalAngle = -90f;
    [SerializeField] private float maxVerticalAngle = 90f;

    private float cameraPitch;

    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        DisableCursor();
    }

    private void Update()
    {
        LookRotation();
    }

    private void LookRotation()
    {
        Vector2 mouseDelta = InputManager.Instance.GetMouseDelta();

        transform.Rotate(Vector3.up * mouseDelta.x * horizontalSensetivity * Time.deltaTime);

        cameraPitch -= mouseDelta.y * verticalSensetivity * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, minVerticalAngle, maxVerticalAngle);

        cameraTransform.localEulerAngles = Vector3.right * cameraPitch;
    }

    private static void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}