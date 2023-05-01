using UnityEngine;

public class Antivirus1 : AntivirusBase {
    private string virusTag = "Virus";

    [SerializeField] private Transform gun;

    private void Start() {
        InvokeRepeating(nameof(FindTarget), 0f, 0.5f);
    }

    private void Update() {
        if (target == null) return;

        LookAtTarget();

        if (fireCooldown <= 0f) {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    public override void FindTarget() {
        // finds all game objects in the scene that has the "virus" tag
        GameObject[] viruses = GameObject.FindGameObjectsWithTag(virusTag);

        // variables for determining who's the nearest enemy
        float minDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // finding the nearest enemy
        foreach (GameObject virus in viruses) {
            if (virus is PopUp) return;
            float distance = Vector3.Distance(transform.position, virus.transform.position);

            if (distance < minDistance) {
                minDistance = distance;
                nearestEnemy = virus;
            }
        }

        if (nearestEnemy != null && minDistance <= range) {
            target = nearestEnemy.transform;
        }
        else target = null;
    }

    private void LookAtTarget() {
        Vector2 dir = target.position - gun.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        gun.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    // TODO: shoot
    public override void Shoot() {
        GameObject projectileGO = ObjectPool.Instance.GetPooledObject("Projectile");
        if (projectileGO != null) {
            projectileGO.transform.SetPositionAndRotation(gun.position, gun.rotation);
            projectileGO.SetActive(true);
            var projectile = projectileGO.GetComponent<Projectile>();
            projectile.FindTarget(target);
        }
    }
}
