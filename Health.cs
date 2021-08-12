using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 5;

    private int currentHealth;

    public GameObject deathCanvas;

    public GameObject playerCanvas;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        float currentHealthPct = (float)currentHealth / (float)startingHealth;
        OnHealthPctChanged(currentHealthPct);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void GiveHealth(int healthAmount)
    {
        currentHealth += healthAmount;

        float currentHealthPct = (float)currentHealth / (float)startingHealth;
        OnHealthPctChanged(currentHealthPct);

        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        playerCanvas.SetActive(false);
        deathCanvas.SetActive(true);
        
    }
}
