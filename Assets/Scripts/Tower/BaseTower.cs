using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{

    public float TimeOnAttack;
    public float attackDistance;
    public float damage;
    public GameObject currentTarget = null;
    public bool GameOver = false;

    [SerializeField] private GameObject Head;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] protected Transform _attackPoint;
    private Animator _animator;
    private float attackCooldown;


    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        _animator.SetBool("Searching", true);
    }

    protected virtual void Update()
    {
        if(GameOver)
        {
            return;
        }

        attackCooldown -= Time.deltaTime;

        if (currentTarget == null)
        {
            DeactivateTower();
            ChangeTarget();
            return;
        }



        if(Vector3.Distance(_attackPoint.position, currentTarget.transform.position) <= attackDistance )
        {
            FaceTarget();
            if (attackCooldown <= 0) 
            {
                Attack();
            }
        }
        else
        {
            DeactivateTower();
            ChangeTarget();            
        }

    }

    protected virtual void DeactivateTower()
    {
        _animator.SetBool("Searching", true);
    }

    private void ChangeTarget()
    {
        GameObject[] creeps = GameObject.FindGameObjectsWithTag("Creep");
        
        float dist = float.MaxValue, tempDist;
        currentTarget = null;

        foreach (var enemy in creeps)
        {
            tempDist = Vector3.Distance(_attackPoint.position, enemy.transform.position);

            if ( tempDist < dist)
            {
                dist = tempDist;
                currentTarget = enemy;
            }
        }

        if(currentTarget != null)
        {
            _animator.SetBool("Searching", false);
        }

    }

    protected virtual void FaceTarget()
    {
        Vector3 t = currentTarget.transform.position;
        t.y += 1;
        Head.GetComponent<Transform>().LookAt(t);
    }

    protected virtual void Attack()
    {
        attackCooldown = TimeOnAttack;
        _animator.SetTrigger("Attack");
    }
}
