using UnityEngine;

namespace Character.Component
{
    public class HealthIndicator : MonoBehaviour
    {
        private TextMesh textMesh;
        private HealthComponent healthComponent;

        private void Start()
        {
            textMesh = GetComponent<TextMesh>();
            healthComponent = GetComponentInParent<HealthComponent>();
            IndicatorUpdate(healthComponent.health);
            healthComponent.OnHealthChanged += IndicatorUpdate;
        }

        private void IndicatorUpdate(int value)
        {
            textMesh.text = value > 0 ? value.ToString() : "";
        }
    }
}