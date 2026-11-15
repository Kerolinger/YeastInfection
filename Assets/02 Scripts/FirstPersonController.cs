using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5.5f;
    [SerializeField] private float runningSpeed = 9.0f;

    private Vector2 moveInput;
    private Vector3 moveDirection;

    private float currentMoveSpeed;
    private Rigidbody rb;

    public Vector2 MoveInput { get => moveInput; set => moveInput = value; }

    private void Start()
    {
        currentMoveSpeed = walkSpeed;
        rb = GetComponentInChildren<Rigidbody>();
    }
    private void Update()
    {
        if(GameManager.Instance.IsMovementInputDisabled)
            return;

        Vector3 moveDirection =
            rb.transform.forward * moveInput.y +
            rb.transform.right * moveInput.x;

        rb.transform.position += moveDirection * currentMoveSpeed * Time.deltaTime;
    }
    public void Interact()
    {
        if (GameManager.Instance.IsMovementInputDisabled)
            return;

        if (!GameManager.Instance.IsEndgame)
        {
            GameManager.Instance.CheckForLightSwitch();
        }
        else
        {
            GameManager.Instance.TryWinGame();
        }
    }
}
