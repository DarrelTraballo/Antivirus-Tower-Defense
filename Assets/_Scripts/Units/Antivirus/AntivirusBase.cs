using UnityEngine;
using UnityEngine.UI;

public abstract class AntivirusBase : MonoBehaviour {
    [HideInInspector] public Tile occupiedTile;

    [Header("Antivirus Properties")]
    public AntivirusData antivirusData;
    public UnitType unitType;

    protected string unitName;
    [SerializeField] protected float range;
    protected float health;
    protected float startHealth;
    protected float healthDepletionRate;
    protected float fireRate;
    protected float fireCooldown = 0f;
    [SerializeField] protected float baseDamage;
    [SerializeField] protected Transform target;

    protected Projectile projectilePrefab;
    [SerializeField] protected Image healthBar;
    [SerializeField] protected Canvas healthCanvas;

    private void OnEnable() {
        unitName = antivirusData.unitName;
        range = antivirusData.range;
        startHealth = antivirusData.health;
        healthDepletionRate = antivirusData.healthDepletionRate;
        fireRate = antivirusData.fireRate;
        baseDamage = antivirusData.baseDamage;
        projectilePrefab = antivirusData.projectilePrefab;

        healthCanvas.enabled = false;
        health = startHealth;
    }

    public abstract void FindTarget();
    public abstract void Shoot();

    private void DisplayRange() {
        if (range == 0) return;


    }

    public void TakeDamage(float amount) {
        healthCanvas.enabled = true;
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0) {
            if (this is ThisPC) {
                GameManager.Instance.ChangeState(GameState.GameOver);
            }
            else Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
