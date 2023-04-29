using UnityEngine;

public abstract class AntivirusBase : MonoBehaviour {
    public Tile occupiedTile;
    public UnitType unitType;
    public AntivirusData antivirusData;

    protected float range;
    protected float health;
    protected float fireRate;
    [SerializeField] protected Transform target;

    [SerializeField] protected AntivirusData antiVirusData;

    private void OnEnable() {
        range = antiVirusData.range;
        health = antiVirusData.health;
        fireRate = antiVirusData.fireRate;
    }

    public abstract void FindTarget();
}
