using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float camSensitivity;

    [SerializeField] private float lookAngleLimitUp;
    [SerializeField] private float lookAngleLimitDown;

    [SerializeField] private Transform playerOrientation;

    float lookAngle;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (GameManager.Instance.IsCameraInputDisabled)
            return;

        Vector2 mouseDelta = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());

        lookAngle += -mouseDelta.y * camSensitivity * Time.deltaTime;
        lookAngle = Mathf.Clamp(lookAngle, lookAngleLimitUp, lookAngleLimitDown);

        transform.localRotation = Quaternion.Euler(lookAngle, /*mouseDelta.x * camSensitivity * Time.deltaTime*/0, 0);
        InputController.Instance.RotatePlayer(mouseDelta.x, camSensitivity);
    }
}
