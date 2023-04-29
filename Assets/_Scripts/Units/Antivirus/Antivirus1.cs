using UnityEngine;

public class Antivirus1 : AntivirusBase {
    private string virusTag = "Virus";

    [SerializeField] private Transform gun;

    private void Start() {
        InvokeRepeating(nameof(FindTarget), 0f, 0.5f);
    }

    private void Update() {
        if (target == null) return;

        Vector2 dir = target.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    public override void FindTarget() {
        GameObject[] viruses = GameObject.FindGameObjectsWithTag(virusTag);
        float minDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject virus in viruses) {
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
}
