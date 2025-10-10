using UnityEngine;

public class SwordAttackSound : MonoBehaviour
{

    [SerializeField] private AudioClip swordSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySwordSound()
    {
        audioSource.PlayOneShot(swordSound);
    }

}
