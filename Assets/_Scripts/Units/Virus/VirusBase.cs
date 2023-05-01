using UnityEngine;

public abstract class VirusBase : MonoBehaviour {
    protected float health;
    protected float speed;
    protected float baseDamage;
    protected Transform target;

    [SerializeField] protected VirusData virusData;

    public abstract void Pathfind();

    private void OnEnable() {
        speed = virusData.speed;
        health = virusData.health;
        baseDamage = virusData.baseDamage;
    }

    public void Release() {
        ObjectPool.Instance.ReleaseObject(gameObject);
    }

    public void TakeDamage(int amount) {
        health -= amount;

        if (health <= 0) {
            Release();
        }
    }
}
