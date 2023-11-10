using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthbarSlider;
    private Quaternion startRotation;

    private void Awake()
    {
        startRotation = transform.rotation;
    }
    private void LateUpdate()
    {
        transform.rotation = startRotation;
    }
    
    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        healthbarSlider.maxValue = maxHealth;
        healthbarSlider.minValue = 0;
        healthbarSlider.value = currentHealth;
    }

}
