using UnityEngine;

public abstract class VirusBase : MonoBehaviour {
    protected float speed;
    protected float health;
    protected Transform target;

    [SerializeField] protected VirusData virusData;

    public abstract void Pathfind();

    private void OnEnable() {
        speed = virusData.speed;
        health = virusData.health;
    }
}
