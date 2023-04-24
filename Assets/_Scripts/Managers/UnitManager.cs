using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour {
    public static UnitManager Instance;

    private List<AntivirusData> units;

    public AntivirusBase selectedAntivirus;

    private UnitManager() { }

    private void Awake() {
        Instance = this;

        units = Resources.LoadAll<AntivirusData>("Units").ToList();
    }

    public void BuildTurret() {
        var turret = GetUnit(UnitType.Antivirus);
        var spawnedTurret = Instantiate(turret);
        var tile = GridManager.Instance.GetTileAtPosition((Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition));

        tile.SetUnit(spawnedTurret, tile);
    }

    public void PlaceThisPC() {
        var thisPC = GetUnit(UnitType.ThisPC);
        var spawnedTurret = Instantiate(thisPC);
        var tile = GridManager.Instance.GetThisPCSpawnTile();

        tile.SetUnit(spawnedTurret, tile);
    }

    public AntivirusBase GetUnit(UnitType unitType) {
        return units.Where(u => u.unitType == unitType).OrderBy(r => Random.value).First().unitPrefab;
    }

    public void SetSelectedAntivirus(AntivirusBase antivirus) {
        selectedAntivirus = antivirus;
    }
}

public enum UnitType {
    ThisPC = 0,
    Antivirus = 1,
    Virus = 2
}
