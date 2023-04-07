using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {
    public static ShopManager Instance;

    private void Awake() {
        Instance = this;
    }

    public void Test() {
        Debug.Log("lmao");

        //UnitManager.Instance.BuildTurret();
    }
}
