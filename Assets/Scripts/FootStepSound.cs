using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private CharacterController controller;
    [Header("Step Settings")]
    public float stepInterval = 0.5f; // Time interval between steps
    private float stepTimer;

    private Vector2 moveInput;
    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }

    void Start()
    {
        stepTimer = stepInterval;
    }

    void Update()
    {
        if (moveInput.magnitude > 0.1f && controller.isGrounded)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                audioSource.PlayOneShot(footstepSound);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f; // reset timer if stopped
        }
    }
}