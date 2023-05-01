using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float fillAmount;
    [SerializeField] private Image content;

    public float MaxValue { get; set; }
    public float Value {
        set {
            fillAmount = Convert(value, 0, MaxValue, 0, 1);
        }
    }
    private void Update() {
        UpdateHealthBar();
    }
    private void UpdateHealthBar() {
        if (fillAmount != content.fillAmount) {
            content.fillAmount = fillAmount;
        }
    }

    private float Convert(float value, float inMin, float inMax, float outMin, float outMax) {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
