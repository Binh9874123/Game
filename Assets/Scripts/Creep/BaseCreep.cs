using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCreep : MonoBehaviour
{
    public GameObject Target;

    public float healthPoints;
    public float moveSpeed;
    public short money;
    public float damage;

    private float _curHealth;
    private float _curMoveSpeed;

    private NavMeshAgent _agent;
    private BattleManager _manager;
    [SerializeField] HealthBar _healthBar;
    [SerializeField] GameObject _creepBody;

    private void Awake()
    {
        _curHealth = healthPoints;
        _curMoveSpeed = moveSpeed;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _creepBody.GetComponent<Animator>().SetFloat("Speed", _agent.speed);
        if (Vector3.Distance(transform.position, Target.transform.position) <= 1)
        {
            //Debug.Log("Attack tower");
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        _agent.speed = 0;
        _creepBody.GetComponent<Animator>().SetTrigger("Attack");
        //Debug.Log(_creepBody.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).fullPathHash);
        yield return new WaitForSeconds(1);
        Target.GetComponent<BaseCastle>().GetHit(damage);
        yield return new WaitForSeconds(1 / 2);
        _manager.DeleteUinit(gameObject);
    }

    IEnumerator Die()
    {
        _creepBody.GetComponent<Animator>().SetBool("isDead", true);
        yield return new WaitForSeconds(1);
    }

    public void GetHit(float dmg)
    {
        _curHealth -= dmg;
        _healthBar.ChangeHP(healthPoints, _curHealth);
        if (_curHealth <= 0) 
        {
            StartCoroutine(Die());
            _manager.UnitKilled(gameObject);
        }
    }

    public void SetTarget(GameObject _t)
    {
        Target = _t;
        _agent.SetDestination(Target.transform.position);
    }

    public void SetManager(BattleManager man)
    {
        _manager = man;
    }

    public short GetMoney()
    {
        return money;
    }

    public void PlayWinAnimation()
    {
        _agent.speed = 0;
        _agent.isStopped = true;
        _creepBody.GetComponent<Animator>().SetBool("Win", true);
    }


}
