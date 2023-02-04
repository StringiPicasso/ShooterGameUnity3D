using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
    [SerializeField] private float _rangeAttack;

    void Update()
    {
        if (Target == null|| Vector3.Distance(transform.position, Target.transform.position) > _rangeAttack)
        {
            NeedTransit = true;
        }
    }
}
