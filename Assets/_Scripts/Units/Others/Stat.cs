using UnityEngine;

[System.Serializable]
public class Stat {
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public float CurrentValue {
        get => this.currentHealth;
        set {
            this.currentHealth = value;
            healthBar.Value = currentHealth;
        }
    }

    public float MaxValue {
        get => this.maxHealth;
        set {
            this.maxHealth = value;
            healthBar.MaxValue = value;
        }
    }
}
