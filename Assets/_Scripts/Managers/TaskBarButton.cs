using UnityEngine;

public class TaskBarButton : MonoBehaviour {

    [SerializeField]
    private AntivirusBase antivirusPrefab;
    public AntivirusBase AntivirusPrefab { get => this.antivirusPrefab; set => this.antivirusPrefab = value; }

}
