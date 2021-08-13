using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCastle : MonoBehaviour
{
    public float healthPoints;
    private float _curHealth;
    [SerializeField] private GameLogicManager _logicManager;
    [SerializeField] HealthBar _healthBar;

    private void Awake()
    {
        _curHealth = healthPoints;
    }

    public void GetHit(float dmg)
    {
        _curHealth -= dmg;
        _healthBar.ChangeHP(healthPoints, _curHealth);
        if (_curHealth <= 0)
        {
            _logicManager.GameOver();
        }
    }
}