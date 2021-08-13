using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{
    public short _money;
    [SerializeField] private Text MoneyUI;
    [SerializeField] private GameObject StartWave;
    [SerializeField] private BattleManager _battleManager;
    [SerializeField] private ScenesController _scenesController;
    [SerializeField] private GameObject _shopPanel;

    private void Start()
    {
        MoneyChanged();
    }

    public void AddMoney(short earned)
    {        
        _money += earned;
        MoneyChanged();
    }

    public short GetMoney()
    {
        MoneyChanged();
        return _money;
    }

    public bool PayMoney(short money)
    {        
        if (_money >= money)
        {
            _money -= money;
            MoneyChanged();
            return true;            
        }
        return false;
    }

    private void MoneyChanged()
    {
        MoneyUI.text = string.Concat("Money ", _money.ToString());
    }

    public void WaveStarted()
    {
        StartWave.SetActive(false);
        _battleManager.StartWave();
    }

    public void WaveEnded()
    {
        StartWave.SetActive(true);
    }

    public void GameOver()
    {
        _shopPanel.SetActive(false);
        _battleManager.GameOver();
    }

}
