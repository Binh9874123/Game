using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : BaseTower
{
    private Vector3 _laserScale;
    [SerializeField]
    private Transform laser;

    protected override void Awake()
    {
        _laserScale = laser.localScale;
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

    protected override void Attack()
    {
        base.Attack();
        Vector3 t = currentTarget.transform.position;
        t.y += 1;
        float d = Vector3.Distance(_attackPoint.position, t);
        _laserScale.z = d / 2;
        laser.localScale = _laserScale;
        laser.position = _attackPoint.position + 0.5f * d * laser.forward;

        currentTarget.GetComponent<BaseCreep>().GetHit(damage * Time.deltaTime);        
    }

    protected override void DeactivateTower()
    {
        laser.localScale = Vector3.zero;
        base.DeactivateTower();        
    }


}
