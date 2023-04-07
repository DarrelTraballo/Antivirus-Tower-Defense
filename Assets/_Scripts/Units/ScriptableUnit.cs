using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject {
    public UnitType unitType;
    public BaseUnit unitPrefab;
}

public enum UnitType {
    ThisPC = 0,
    Antivirus = 1,
    Virus = 2
}
