using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [System.Serializable]
    public class Wave {
        public string name;
        public Transform enemyPrefab;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    private int nextWave = 0;
    public float timeBetweenWaves = 2f;
    public float waveCountdown;

    private float searchCountdown = 1f;
    private string virusTag = "Virus";

    [SerializeField]
    private Transform parent;


    private GameManager gameManager;

    private void Awake() {
        gameManager = GameManager.Instance;
    }

    private void Start() {
        waveCountdown = timeBetweenWaves;

        if (spawnPoints.Length == 0) {
            Debug.LogError("No Spawn Points set.");
        }
    }

    private void Update() {

        if (GameManager.Instance.state == GameState.KillWaveState) {
            // Checks if there are any more shitters alive before continuing on to next wave
            if (!AreEnemiesAlive()) {
                // start next wave
                WaveCompleted();
                return;
            }
            else {
                return;
            }
        }

        if (waveCountdown <= 0) {
            if (GameManager.Instance.state == GameState.PreparationState) {
                // Start spawning shit
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else {
            waveCountdown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave(Wave wave) {
        GameManager.Instance.ChangeState(GameState.WaveStartState);

        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        GameManager.Instance.ChangeState(GameState.KillWaveState);

        yield break;
    }

    private void SpawnEnemy(Transform enemy) {
        Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, chosenSpawnPoint.position, chosenSpawnPoint.rotation, parent);

        //Debug.Log("Spawning shitters");
    }

    private void WaveCompleted() {
        //Debug.Log("Wave Completed");

        GameManager.Instance.ChangeState(GameState.PreparationState);
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) {
            nextWave = 0;
            //Debug.Log("All waves done. starting it all over again :)");
        }
        else {
            nextWave++;
        }
    }

    private bool AreEnemiesAlive() {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag(virusTag) == null) {
                return false;
            }
        }

        return true;
    }
}
