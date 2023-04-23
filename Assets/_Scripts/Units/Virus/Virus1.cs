using UnityEngine;

public class Virus1 : VirusBase {

    private Transform target;
    private float distance;

    private void Start() {
        target = FindObjectOfType<ThisPC>().transform;

        if (target != null) {
            //Debug.Log(target.transform.position);
            //Debug.Log(target.name, target.gameObject);
        }
        else {
            Debug.Log("no object found");
        }
    }

    private void Update() {
        Pathfind();
    }

    public override void Pathfind() {
        if (target != null) {
            distance = Vector2.Distance(transform.position, target.position);
            Vector2 dir = target.position - transform.position;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            if (distance <= 0) {
                Destroy(gameObject);
                // TODO: Deal damage to This PC
            }
        }
    }
}
