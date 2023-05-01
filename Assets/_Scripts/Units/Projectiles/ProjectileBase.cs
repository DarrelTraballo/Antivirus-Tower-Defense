using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour {

    protected Transform target;
    [SerializeField] protected ProjectileData projectileData;

    protected float projectileSpeed;
    protected float distance;
    public float Damage { get; set; }

    private void OnEnable() {
        projectileSpeed = projectileData.projectileSpeed;
    }

    void Update() {
        if (!target.gameObject.activeInHierarchy) {
            ReturnToPool();
            //return;
        }

        MoveTowardsTarget();
    }

    public void SetTarget(Transform _target) {
        if (_target == null) ReturnToPool();
        target = _target;
    }

    private void MoveTowardsTarget() {
        distance = Vector2.Distance(transform.position, target.position);
        Vector2 dir = target.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.position, projectileSpeed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));

    }

    public void ReturnToPool() {
        ObjectPool.Instance.ReleaseObject(gameObject);
    }

    private void DealDamage() {
        if (this.target.TryGetComponent<VirusBase>(out var enemy)) {
            enemy.TakeDamage(Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Virus")) {
            Debug.Log("Hit");
            DealDamage();
            ReturnToPool();
        }
    }
}
