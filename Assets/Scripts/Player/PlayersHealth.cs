using UnityEngine;
using UnityEngine.UI;

public class PlayersHealth : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void ApplyDamage(int Damage)
    {
        currentHealth -= Damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            healthSlider.value = healthPercentage;
        }
    }

    public void Die()
    {
        Debug.Log("Object has died.");
        Destroy(gameObject);
    }

}
