using UnityEngine;

[CreateAssetMenu(fileName = "New Virus", menuName = "Unit/Virus")]
public class VirusData : ScriptableObject {
    public string unitName;
    [TextArea]
    public string unitDescription;

    public UnitType unitType;
    public VirusBase unitPrefab;

    public float health;
    public float speed;
    public float baseDamage;
    public Transform Target { get; private set; }
}
