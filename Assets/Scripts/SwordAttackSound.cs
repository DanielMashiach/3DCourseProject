using UnityEngine;

public class SwordAttackSound : MonoBehaviour
{
    [SerializeField] private AudioClip swordSound;
    [SerializeField] private AudioSource audioSource;

    public void PlaySwordSound()
    {
        if (audioSource != null && swordSound != null)
            audioSource.PlayOneShot(swordSound);
    }
}