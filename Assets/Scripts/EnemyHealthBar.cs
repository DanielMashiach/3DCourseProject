using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Vector3 offset = new Vector3(0, 2f, 0);
    [SerializeField] private float lerpSpeed = 8f;

    private float displayValue = 1f;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;

        if (enemyHealth == null) return;

        if (healthSlider != null)
        {
            healthSlider.minValue = 0f;
            healthSlider.maxValue = 1f;
            healthSlider.value = 1f;
            displayValue = 1f;
        }

        if (fillImage != null)
        {
            fillImage.type = Image.Type.Filled;
            fillImage.fillMethod = Image.FillMethod.Horizontal;
            fillImage.fillOrigin = 0;
            fillImage.fillAmount = 1f;
            displayValue = 1f;
        }
    }

    void LateUpdate()
    {
        if (enemyHealth == null) return;

        transform.position = enemyHealth.transform.position + offset;

        if (mainCam != null)
            transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);

        float target = (float)enemyHealth.CurrentHealth / Mathf.Max(1, enemyHealth.MaxHealth);

        displayValue = Mathf.Lerp(displayValue, target, Time.deltaTime * lerpSpeed);

        if (healthSlider != null)
            healthSlider.value = displayValue;

        if (fillImage != null)
            fillImage.fillAmount = displayValue;
    }
}