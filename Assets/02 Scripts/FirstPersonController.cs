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
    private Animator animator;

    public Vector2 MoveInput { get => moveInput; set => moveInput = value; }

    private void Start()
    {
        currentMoveSpeed = walkSpeed;
        rb = GetComponentInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if(GameManager.Instance.IsMovementInputDisabled)
            return;

        Vector3 moveDirection =
            rb.transform.forward * moveInput.y +
            rb.transform.right * moveInput.x;

        rb.transform.position += moveDirection * currentMoveSpeed * Time.deltaTime;

        if (moveDirection == Vector3.zero)
            animator.SetBool("IsWalking", false);
        else
            animator.SetBool("IsWalking", true);
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
