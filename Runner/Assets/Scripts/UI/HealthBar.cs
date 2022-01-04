using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.Health;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChenged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChenged;
    }

    private void OnHealthChenged(int health)
    {
        _slider.value = Mathf.MoveTowards(_slider.minValue, _slider.maxValue, health);
    }
}
