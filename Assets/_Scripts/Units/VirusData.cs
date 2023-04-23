using UnityEngine;

[CreateAssetMenu(fileName = "New Virus", menuName = "Unit/Virus")]
public class VirusData : ScriptableObject {
    public string unitName;
    [TextArea]
    public string unitDescription;

    public UnitType unitType;
    public VirusBase unitPrefab;

    public int health;
    public float speed;
}
