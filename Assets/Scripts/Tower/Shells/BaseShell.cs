using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShell : MonoBehaviour
{
    private GameObject _target = null;
    public float Speed;
    private float _damage;

    public void SetTarget(GameObject t)
    {
        _target = t;
    }

    public void SetDamage(float dmg)
    {
        _damage = dmg;
    }

    private void Update()
    {
        if (_target == null || Vector3.Distance(transform.position, _target.transform.position) > 1000)
        {
            Destroy(gameObject);
            return;
        }

        if(Vector3.Distance(transform.position, _target.transform.position) <= 1.5f)
        {
            _target.GetComponent<BaseCreep>().GetHit(_damage);
            Destroy(gameObject);
        }
        else
        {
           Vector3 t = _target.transform.position;
           t.y += 1f;
           transform.position = Vector3.MoveTowards(transform.position, t, Speed * Time.deltaTime);
           transform.LookAt(_target.transform.position);
        }
    }
}
