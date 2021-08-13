using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BattleManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject _creepExample;
    public GameObject creepTarget;
    public float delay;
    private List<BaseCreep> _creeps = new List<BaseCreep>();
    private List<BaseTower> _towers = new List<BaseTower>();
    private short _creepsNum = 7;
    [SerializeField] private GameLogicManager _logicManager;

    public void StartWave()
    {
        StartCoroutine(CreateWithDelay());
        _creepsNum++;
    }

    IEnumerator CreateWithDelay()
    {
        for (int i = 0; i < _creepsNum; i++)
        {
            CreateCreep();
            yield return new WaitForSeconds(delay);
        }
    }

    private void CreateCreep()
    {
        GameObject newCreep =  Instantiate(_creepExample, spawnPoint.position, spawnPoint.rotation);
        _creeps.Add(newCreep.GetComponent<BaseCreep>());
        newCreep.GetComponent<BaseCreep>().SetTarget(creepTarget);
        newCreep.GetComponent<BaseCreep>().SetManager(this.GetComponent<BattleManager>());
    }

    public void CreateTower(GameObject newTower)
    {
        _towers.Add(newTower.GetComponent<BaseTower>());
    }

    public void UnitKilled(GameObject unit)
    {
        _logicManager.AddMoney(unit.GetComponent<BaseCreep>().GetMoney());
        _creeps.Remove(unit.GetComponent<BaseCreep>());
        Destroy(unit);  
        
        if(_creeps.Count == 0)
        {
            _logicManager.WaveEnded();
        }
    }

    public void DeleteUinit(GameObject unit)
    {
        _creeps.Remove(unit.GetComponent<BaseCreep>());
        Destroy(unit);
    }

    public void GameOver()
    {
        foreach(var creep in _creeps)
        {
            //creep.PlayWinAnimation();
            creep.GetComponent<NavMeshAgent>().isStopped = true;
        }

        foreach(var tower in _towers)
        {
            tower.GameOver = true;
            tower.GetComponent<Animator>().SetBool("Loss", true);
        }
    }
}
