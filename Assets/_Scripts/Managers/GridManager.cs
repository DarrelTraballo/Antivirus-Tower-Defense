using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public static GridManager Instance;

    [SerializeField] public int Width { get; private set; } = 20;
    [SerializeField] public int Height { get; private set; } = 9;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform Wallpaper;
    [SerializeField] private Transform gridArea;

    private Dictionary<Vector2, Tile> tiles;

    private Vector3 cameraOffset;

    private Vector2 offset;
    public readonly float tileSize = 1f;

    private Dictionary<Vector2, Tile> taskBarTiles;
    private int taskBarWidth = 20, taskBarHeight = 1;
    [SerializeField] private Transform taskBarArea;

    private GridManager() { }

    private void Awake() {
        Instance = this;
        cameraOffset = new Vector3((float) Width / 2 - 0.5f, ((float) Height / 2 - 0.5f) - 1f, -10);
        Wallpaper.transform.position = new Vector3((float) Width / 2 - 0.5f, ((float) Height / 2 - 0.5f) - 1f, 10);
    }

    public void GenerateGrid() {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < Width; x++) {
            for (int y = 0; y < Height; y++) {
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

    public void GenerateTaskbarGrid() {
        taskBarTiles = new Dictionary<Vector2, Tile>();
        //taskBarArea.gameObject.SetActive(true);

        for (int x = 0; x < taskBarWidth; x++) {
            for (int y = 0; y < taskBarHeight; y++) {
                var taskBarTile = Instantiate(tilePrefab, new Vector3(x, y - 2f, 0), Quaternion.identity, taskBarArea);
                taskBarTile.name = $"Taskbar ({x}, {y})";

                var isOffset = (x + y) % 2 == 1;
                taskBarTile.Init(isOffset);

                taskBarTiles[new Vector2(x, y)] = taskBarTile;
            }
        }
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
        return tiles.Where(t => t.Key.x == 0f && t.Key.y == Height - 1).First().Value;
    }
}
