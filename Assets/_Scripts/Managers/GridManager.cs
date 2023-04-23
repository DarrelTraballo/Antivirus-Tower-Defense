using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public static GridManager Instance;

    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform Wallpaper;
    [SerializeField] private Transform gridArea;
    [SerializeField] private ThisPC thisPC;

    private Dictionary<Vector2, Tile> tiles;

    private Vector3 cameraOffset;

    private Vector2 offset;
    private readonly float tileSize = 1f;

    private void Awake() {
        Instance = this;
        cameraOffset = new Vector3((float) width / 2 - 0.5f, ((float) height / 2 - 0.5f) - 1f, -10);
        Wallpaper.transform.position = new Vector3((float) width / 2 - 0.5f, ((float) height / 2 - 0.5f) - 1f, 10);
    }

    public void GenerateGrid() {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, gridArea);

                spawnedTile.name = $"({x}, {y})";

                var isOffset = (x + y) % 2 == 1;
                spawnedTile.Init(isOffset);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        cam.transform.position = cameraOffset;

        UnitManager.Instance.PlaceThisPC();

        GameManager.Instance.ChangeState(GameState.PreparationState);
    }

    public Tile GetTileAtPosition(Vector2 position) {
        Vector2 gridPos = (position - offset) / tileSize;
        Vector2Int key = new Vector2Int(Mathf.RoundToInt(gridPos.x), Mathf.RoundToInt(gridPos.y));
        if (tiles.ContainsKey(key)) {
            return tiles[key];
        }
        return null;
    }

    public Tile GetThisPCSpawnTile() {
        return tiles.Where(t => t.Key.x == 0f && t.Key.y == height - 1).First().Value;
    }
}
