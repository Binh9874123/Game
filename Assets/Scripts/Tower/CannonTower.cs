using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : BaseTower
{
    [SerializeField]
    private GameObject CannonBall;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FaceTarget()
    {
        base.FaceTarget();
    }

    protected override void DeactivateTower()
    {
        base.DeactivateTower();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject ball = Instantiate(CannonBall, _attackPoint.position, transform.rotation);
        ball.GetComponent<BaseShell>().SetDamage(damage);
        ball.GetComponent<BaseShell>().SetTarget(currentTarget);
        
    }


}
