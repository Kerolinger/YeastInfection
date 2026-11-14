using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputController : MonoBehaviour
{
    //private PlayerInput playerInput;
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private CameraMovement cameraMovement;

    private InputAction moveInput;
    private InputAction interactInput;
    private Rigidbody rb;

    static public InputController Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //playerInput = new PlayerInput();

        moveInput = InputSystem.actions.FindAction("Move");
        interactInput = InputSystem.actions.FindAction("Interact");
        rb = GetComponentInChildren<Rigidbody>();  

        interactInput.started += context =>
        {
            firstPersonController.Interact();
        };

        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
        }

    }

    void Update()
    {
        firstPersonController.MoveInput = moveInput.ReadValue<Vector2>();
        rb.transform.localPosition = Vector3.zero;
    }


    public void RotatePlayer(float mouseDeltaX, float lookSensitivity)
    {
        firstPersonController.transform.rotation *= Quaternion.Euler(0, mouseDeltaX * lookSensitivity* Time.deltaTime, 0);
    }

}
