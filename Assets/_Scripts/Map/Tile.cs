using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    public AntivirusBase occupiedUnit;
    private bool dragging;

    private Vector2 mousePos;

    private UnitManager unitManager;
    private GameManager gameManager;
    private GridManager gridManager;

    private void Awake() {
        unitManager = UnitManager.Instance;
        gameManager = GameManager.Instance;
        gridManager = GridManager.Instance;
    }

    public void Init(bool isOffset) {
        renderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter() {
        highlight.SetActive(true);
    }

    private void OnMouseExit() {
        highlight.SetActive(false);
    }

    private void Update() {
        if (!dragging) return;

        mousePos = GetMousePosition();

        if (occupiedUnit != null) {
            occupiedUnit.transform.position = mousePos;
        }
    }
    private void OnMouseDown() {
        //if (gameManager.state != GameState.PreparationState) return;
        mousePos = GetMousePosition();
        // if clicked on an occupied tile
        if (occupiedUnit != null) {
            dragging = true;
            //Debug.Log(occupiedUnit);
            if (occupiedUnit.unitType == UnitType.ThisPC || occupiedUnit.unitType == UnitType.Antivirus) {
                unitManager.SetSelectedAntivirus(occupiedUnit);
            }
        }

        // if clicked on an empty tile
        else {
            //unitManager.BuildTurret();
        }
    }

    private void OnMouseUp() {
        mousePos = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (occupiedUnit != null) {
            if (unitManager.selectedAntivirus != null) {
                // check if out of bounds
                bool isMouseOutOfBounds = mousePos.y < 0 - (GridManager.Instance.tileSize / 2) || mousePos.y > GridManager.Instance.Height || mousePos.x < 0 - (GridManager.Instance.tileSize / 2) || mousePos.x > GridManager.Instance.Width;

                if (isMouseOutOfBounds) {
                    SetUnit(unitManager.selectedAntivirus, occupiedUnit.occupiedTile);
                    unitManager.SetSelectedAntivirus(null);
                    dragging = false;
                    return;
                }
                // move the unit
                var droppedTile = gridManager.GetTileAtPosition(mousePos);
                SetUnit(unitManager.selectedAntivirus, droppedTile);

                unitManager.SetSelectedAntivirus(null);
                dragging = false;

            }
        }
    }
    public void SetUnit(AntivirusBase unit, Tile tile) {
        if (unit.occupiedTile != null) unit.occupiedTile.occupiedUnit = null;
        unit.transform.position = tile.transform.position;
        tile.occupiedUnit = unit;
        unit.occupiedTile = tile;
    }

    private Vector2 GetMousePosition() {
        return (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
