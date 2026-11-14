using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float camSensitivityX;
    [SerializeField] private float camSensitivityY;

    [SerializeField] private float camXMinAngle;
    [SerializeField] private float camXMaxAngle;

    [SerializeField] private Transform playerOrientation;

    private float xRotation;
    private float yRotation;

    private float mouseX;
    private float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * camSensitivityX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * camSensitivityY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, camXMinAngle, camXMaxAngle);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
