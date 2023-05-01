using UnityEngine;

public class Virus1 : VirusBase {

    private float distance;

    private void Start() {
        SetTarget();

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

    /* 
     * TODO: need to try A* on this instead of just moving towards the player
     *       to force enemies to pathfind around defenses set by players
     *       one big problem of this gameplay-wise is players could just cheese the entire game by
     *       trapping enemies inside a cage of defenses.
     *       
     *       OR
     *       
     *       viruses colliding with antivirus units => both units take damage
     *       antivirus units will always deal 1 damage on collision with a virus unit, 
     *       virus units will always deal how much damage is set to them initially.
     *       
     */

    public override void SetTarget() {
        target = FindObjectOfType<ThisPC>().transform;
    }

    public override void Pathfind() {
        if (target != null) {
            distance = Vector2.Distance(transform.position, target.position);
            Vector2 dir = target.position - transform.position;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.SetPositionAndRotation(Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));

            if (distance <= 0f) {
                DealDamage();
                Die();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

    }
}
