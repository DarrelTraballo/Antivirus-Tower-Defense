using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CodeMonkey.Utils;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> units;

    public BaseAntivirus selectedAntivirus;

    private void Awake() {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    /*
     *  MASSIVE TODO: 
     *      LEARN SCRIPTABLE OBJECTS
     *      OVERHAUL ALL THE SCRIPTABLE UNIT SHITTERS
     *      REPLACE THOSE WITH SCRIPTABLE OBJECTS
     *      
     */

    public void BuildTurret() {
        var turret = GetUnit<BaseAntivirus>(UnitType.Antivirus);
        var spawnedTurret = Instantiate(turret);
        var tile = GridManager.Instance.GetTileAtPosition((Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition));

        tile.SetUnit(spawnedTurret, tile);
    }

    public void PlaceThisPC() {
        var thisPC = GetUnit<BaseAntivirus>(UnitType.ThisPC);
        var spawnedTurret = Instantiate(thisPC);
        var tile = GridManager.Instance.GetThisPCSpawnTile();

        tile.SetUnit(spawnedTurret, tile);
    }

    public T GetUnit<T>(UnitType unitType) where T : BaseUnit { 
        return (T)units.Where(u => u.unitType == unitType).OrderBy(r => Random.value).First().unitPrefab;
    }

    public void SetSelectedAntivirus(BaseAntivirus antivirus) {
        selectedAntivirus = antivirus;
    }
}
