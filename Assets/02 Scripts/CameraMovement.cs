using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float camSensitivity;

    [SerializeField] private float lookAngleLimitMin;
    [SerializeField] private float lookAngleLimitMax;

    [SerializeField] private Transform playerOrientation;

    private float xRotation;
    private float yRotation;

    private Vector2 mouseInput;
    private Vector2 mouseDirection;

    float lookAngle;

    public Vector2 MouseInput { get => mouseInput; set => mouseInput = value; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouseDelta = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());

        lookAngle += -mouseDelta.y * camSensitivity * Time.deltaTime;
        Mathf.Clamp(lookAngle, -45, 45);

        transform.localRotation = Quaternion.Euler(lookAngle, 0, 0);
        InputController.Instance.RotatePlayer(mouseDelta.x, camSensitivity);

        //mouseDirection.x = mouseInput.x * Time.deltaTime * camSensitivityX;
        //mouseDirection.y = mouseInput.y * Time.deltaTime * camSensitivityY;

        //yRotation += mouseDirection.x;
        //xRotation -= mouseDirection.y;
        //xRotation = Mathf.Clamp(xRotation, camXMinAngle, camXMaxAngle);

        ////rotate cam and orientation
        //transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
