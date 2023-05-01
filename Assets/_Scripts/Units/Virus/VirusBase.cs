using UnityEngine;
using UnityEngine.UI;

public abstract class VirusBase : MonoBehaviour {
    protected float health;
    protected float startHealth;
    protected float speed;
    protected float baseDamage;
    protected Transform target;

    [SerializeField] protected VirusData virusData;
    [SerializeField] protected Image healthBar;
    [SerializeField] protected Canvas healthCanvas;

    public abstract void SetTarget();
    public abstract void Pathfind();

    private void OnEnable() {
        speed = virusData.speed;
        startHealth = virusData.health;
        baseDamage = virusData.baseDamage;

        healthCanvas.enabled = false;
        health = startHealth;
    }

    public void Die() {
        ObjectPool.Instance.ReleaseObject(gameObject);
    }

    public void TakeDamage(float amount) {
        healthCanvas.enabled = true;
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0) {
            Die();
        }
    }

    public void DealDamage() {
        AntivirusBase antivirus = target.GetComponent<AntivirusBase>();
        if (antivirus != null) {
            antivirus.TakeDamage(baseDamage);
        }
    }
}
