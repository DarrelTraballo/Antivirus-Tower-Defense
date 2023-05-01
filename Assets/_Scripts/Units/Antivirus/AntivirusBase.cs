using UnityEngine;

public abstract class AntivirusBase : MonoBehaviour {
    [HideInInspector] public Tile occupiedTile;

    [Header("Antivirus Properties")]
    public AntivirusData antivirusData;
    public UnitType unitType;

    protected string unitName;
    [SerializeField] protected float range;
    protected float health;
    protected float fireRate;
    protected float fireCooldown = 0f;
    [SerializeField] protected float baseDamage;
    [SerializeField] protected Transform target;

    protected Projectile projectilePrefab;

    private void OnEnable() {
        unitName = antivirusData.unitName;
        range = antivirusData.range;
        health = antivirusData.health;
        fireRate = antivirusData.fireRate;
        baseDamage = antivirusData.baseDamage;
        projectilePrefab = antivirusData.projectilePrefab;
    }

    public abstract void FindTarget();
    public abstract void Shoot();

    private void DisplayRange() {
        if (range == 0) return;


    }

    public void TakeDamage(int amount) {
        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
