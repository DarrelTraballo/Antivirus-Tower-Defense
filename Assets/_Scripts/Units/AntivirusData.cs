using UnityEngine;

[CreateAssetMenu(fileName = "New Antivirus", menuName = "Unit/Antivirus")]
public class AntivirusData : ScriptableObject {
    public string unitName;
    [TextArea]
    public string unitDescription;

    public UnitType unitType;
    public AntivirusBase unitPrefab;

    public int health;
    public float range;
}
