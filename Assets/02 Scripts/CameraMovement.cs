using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float camSensitivity;

    [SerializeField] private float lookAngleLimitUp;
    [SerializeField] private float lookAngleLimitDown;

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
        lookAngle = Mathf.Clamp(lookAngle, lookAngleLimitUp, lookAngleLimitDown);
        Debug.Log(lookAngle);

        transform.localRotation = Quaternion.Euler(lookAngle, /*mouseDelta.x * camSensitivity * Time.deltaTime*/0, 0);
        InputController.Instance.RotatePlayer(mouseDelta.x, camSensitivity);

        //firstPersonController.transform.rotation *= Quaternion.Euler(0, mouseDeltaX * lookSensitivity* Time.deltaTime, 0);

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
