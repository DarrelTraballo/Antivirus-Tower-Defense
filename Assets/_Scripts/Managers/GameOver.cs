using UnityEngine;

public class GameOver : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void PlayAgain() {
        gameObject.SetActive(false);
        GameManager.Instance.ChangeState(GameState.PreparationState);
    }
}
