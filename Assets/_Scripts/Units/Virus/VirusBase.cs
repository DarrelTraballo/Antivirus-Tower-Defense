using UnityEngine;

public abstract class VirusBase : MonoBehaviour {
    [SerializeField] protected float speed;
    //[SerializeField] protected Transform target;

    [SerializeField] protected VirusData virusData;

    public abstract void Pathfind();
}
