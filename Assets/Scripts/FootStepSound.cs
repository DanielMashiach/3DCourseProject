using UnityEngine;
public class FootStepSound : MonoBehaviour
{

    [SerializeField] private AudioClip footstepSound;
    private AudioSource audioSource;
    private CharacterController controller;
    public float stepInterval = 0.5f; // Time interval between steps
    private float stepTimer;

    private Vector2 moveInput;
    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        stepTimer = stepInterval;

    }


    // Update is called once per frame
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
