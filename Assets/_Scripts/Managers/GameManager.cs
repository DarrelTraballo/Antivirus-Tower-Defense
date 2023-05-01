using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public GameState state;
    private static bool isGameOver = false;
    [SerializeField] private GameObject gameOverUI;

    private GameManager() { }

    private void Awake() {
        Instance = this;
        ChangeState(GameState.GenerateGrid);
    }

    public void Start() {

    }

    public void ChangeState(GameState newState) {
        state = newState;

        switch (newState) {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.PreparationState:
                // TODO: reset this pc hp or something
                break;
            case GameState.WaveStartState:
                break;
            case GameState.KillWaveState:
                break;
            case GameState.GameOver:
                // display gameover ui or something
                gameOverUI.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState {
    GenerateGrid,           // setting up the game environment
    PreparationState,       // player sets up shit
    WaveStartState,         // enemies start spawning
    KillWaveState,          // player kills enemies
    GameOver,               // this pc is dead
}
