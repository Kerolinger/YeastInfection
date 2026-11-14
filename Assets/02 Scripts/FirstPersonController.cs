using UnityEngine;
using UnityEngine.EventSystems;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5.5f;
    [SerializeField] private float runningSpeed = 9.0f;

    private Vector2 moveInput;
    private Vector3 moveDirection;

    private float currentMoveSpeed;

    public Vector2 MoveInput { get => moveInput; set => moveInput = value; }

    private void Start()
    {
        currentMoveSpeed = walkSpeed;
    }
    private void Update()
    {
        if(GameManager.Instance.IsMovementInputDisabled)
            return;

        Vector3 moveDirection =
            transform.forward * moveInput.y +
            transform.right * moveInput.x;

        transform.position += moveDirection * currentMoveSpeed * Time.deltaTime;
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
