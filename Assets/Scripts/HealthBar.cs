using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;      
    [SerializeField] private Slider easeHealthSlider;   
    [SerializeField] private float lerpSpeed = 5f;

    private float targetHealth;

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        easeHealthSlider.maxValue = maxHealth;

        healthSlider.value = maxHealth;
        easeHealthSlider.value = maxHealth;
        targetHealth = maxHealth;
    }

    public void SetHealth(int health)
    {
        targetHealth = health;
        healthSlider.value = health;
    }

    void Update()
    {
        if (Mathf.Abs(easeHealthSlider.value - targetHealth) > 0.01f)
        {
            easeHealthSlider.value = Mathf.Lerp(
                easeHealthSlider.value,
                targetHealth,
                Time.deltaTime * lerpSpeed
            );
        }
    }
}