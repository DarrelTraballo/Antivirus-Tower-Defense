using UnityEngine;

public abstract class VirusBase : MonoBehaviour {
    [SerializeField] protected float speed;
    //[SerializeField] protected Transform target;

    [SerializeField] protected VirusData virusData;

    // TODO: try and not make enemy units get on top of each other (lenny)

    public abstract void Pathfind();
}
