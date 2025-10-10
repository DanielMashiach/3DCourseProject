using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    [SerializeField] private Animator swordAnimator;
    [SerializeField] private FootStepSound footsteps;


    // Run before start
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();

    }
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

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
