using UnityEngine;

public class ShopManager : MonoBehaviour {
    public static ShopManager Instance;

    public AntivirusData antivirusData;

    private void Awake() {
        Instance = this;
    }

    public void Test() {
        Debug.Log("lmao");
        // spawn in a folder icon idk



        //UnitManager.Instance.BuildTurret();
    }
}
