using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private Image hpImage;
    void Start()
    {
        currentHealth = maxHealth;
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
        if (hpImage != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            //hpImage.fillAmount = Mathf.Min(1, (Time.time - lastAttackTime) / AtackSpeed)
            hpImage.fillAmount = healthPercentage;
        }
    }

    public void Die()
    {
        Debug.Log("Object has died.");
        Destroy(gameObject);
    }
}
