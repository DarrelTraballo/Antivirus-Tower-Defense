using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Unit/Projectile")]
public class ProjectileData : ScriptableObject {

    public Projectile projectilePrefab;
    public float projectileSpeed;
}
