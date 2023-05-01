using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform target;
    public float projectileSpeed = 20f;
    public float distance;

    public void FindTarget(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update() {
        if (target == null) {
            Release();
            return;
        }

        MoveTowardsTarget();
    }


    private void MoveTowardsTarget() {
        distance = Vector2.Distance(transform.position, target.position);
        Vector2 dir = target.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.position, projectileSpeed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));

        if (distance <= 0f) {
            //Debug.Log("HIT");
            Release();

        }
    }

    public void Release() {
        ObjectPool.Instance.ReleaseObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Virus")) {
            Debug.Log("Hit");
            Release();
        }
    }
}
