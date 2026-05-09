using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image healthBar; // your green Image
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public float drainSpeed = 1f;        // health per second
    public float barSmoothSpeed = 1f;    // smoothing speed

    private float displayedHealth;

    void Start()
    {
        currentHealth = maxHealth;
        displayedHealth = maxHealth;

        // Make sure the Image is type: Filled
        if (healthBar.type != Image.Type.Filled)
            healthBar.type = Image.Type.Filled;
        healthBar.fillMethod = Image.FillMethod.Horizontal;
        healthBar.fillOrigin = 0; // fill from left to right
        healthBar.fillAmount = 1f;
    }

    void Update()
    {
        // Automatic drain
        currentHealth -= drainSpeed * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // Smoothly animate the fill
        displayedHealth = Mathf.MoveTowards(displayedHealth, currentHealth, barSmoothSpeed * Time.deltaTime);
        healthBar.fillAmount = displayedHealth / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }
}