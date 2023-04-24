using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskBarManager : MonoBehaviour {
    public static TaskBarManager Instance;

    private List<AntivirusData> units;
    private TaskBarManager() { }

    private void Awake() {
        Instance = this;

        units = Resources.LoadAll<AntivirusData>("Units").ToList();
    }

    // start_icon | search_icon | new_folder | tower_1 | tower_2

}
