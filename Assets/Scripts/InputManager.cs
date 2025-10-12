using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    [Header("Player Components")]
    [SerializeField] private PlayerMotor motor;
    [SerializeField] private PlayerLook look;

    [Header("Extras")]
    [SerializeField] private Animator swordAnimator;
    [SerializeField] private FootStepSound footsteps;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        onFoot.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        Vector2 move = onFoot.Movement.ReadValue<Vector2>();
        motor.ProcessMove(move);

        if (footsteps != null)
        {
            footsteps.SetMoveInput(move);
        }
    }

    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
        onFoot.Attack.performed += OnAttack;
    }

    private void OnDisable()
    {
        onFoot.Attack.performed -= OnAttack;
        onFoot.Disable();
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        swordAnimator.SetTrigger("Attack");
    }
}