using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    public AntivirusBase occupiedUnit;
    private bool dragging;

    private Vector2 mousePos;

    private UnitManager unitManager;
    private GridManager gridManager;

    private void Awake() {
        unitManager = UnitManager.Instance;
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
        if (GameManager.Instance.state == GameState.GameOver) return;

        mousePos = GetMousePosition();

        if (occupiedUnit != null) {
            occupiedUnit.transform.position = mousePos;
        }
    }
    // when mouse clicks and drags over an antivirus unit
    private void OnMouseDown() {
        if (GameManager.Instance.state == GameState.GameOver) return;
        mousePos = GetMousePosition();
        // if clicked on an occupied tile
        if (occupiedUnit != null) {
            dragging = true;
            if (occupiedUnit.unitType == UnitType.ThisPC || occupiedUnit.unitType == UnitType.Antivirus) {
                unitManager.SetSelectedAntivirus(occupiedUnit);

            }
        }

        // if clicked on an empty tile
        else {
            unitManager.BuildAntivirus();
        }
    }

    // when mouse stops dragging an antivirus unit ; when player lets go of left click
    private void OnMouseUp() {
        mousePos = GetMousePosition();
        var targetTile = gridManager.GetTileAtPosition(mousePos);

        // checks if player is actually holding an antivirus unit
        if (unitManager.selectedAntivirus != null) {
            // check if out of bounds
            bool isMouseOutOfBounds = mousePos.y < 0 - (GridManager.Instance.tileSize / 2) || mousePos.y > GridManager.Instance.Height || mousePos.x < 0 - (GridManager.Instance.tileSize / 2) || mousePos.x > GridManager.Instance.Width;

            if (isMouseOutOfBounds || targetTile.occupiedUnit != null) {
                SetUnit(unitManager.selectedAntivirus, occupiedUnit.occupiedTile);
                unitManager.SetSelectedAntivirus(null);
                dragging = false;
                return;
            }
            // move the unit
            SetUnit(unitManager.selectedAntivirus, targetTile);

            unitManager.SetSelectedAntivirus(null);
            dragging = false;

        }
    }
    public void SetUnit(AntivirusBase unit, Tile tile) {
        if (unit.occupiedTile != null) unit.occupiedTile.occupiedUnit = null;
        unit.transform.position = tile.transform.position;
        tile.occupiedUnit = unit;
        unit.occupiedTile = tile;
        unit.transform.SetParent(tile.transform);
    }

    private Vector2 GetMousePosition() {
        return (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
