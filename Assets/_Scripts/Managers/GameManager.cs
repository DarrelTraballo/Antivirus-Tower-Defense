using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public GameState state;

    private GameManager() { }

    private void Awake() {
        Instance = this;
    }

    public void Start() {
        ChangeState(GameState.GenerateGrid);
    }
    
    public void ChangeState(GameState newState) {
        state = newState;

        switch (newState) {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.PreparationState:
                break;
            case GameState.WaveStartState:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState {
    GenerateGrid,
    PreparationState,
    WaveStartState
}
