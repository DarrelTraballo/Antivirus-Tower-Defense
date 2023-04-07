using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager Instance;

    private GameObject turret;

    private void Awake() {
        Instance = this;
    }

    public GameObject GetTurret() {
        return turret;
    }
}
