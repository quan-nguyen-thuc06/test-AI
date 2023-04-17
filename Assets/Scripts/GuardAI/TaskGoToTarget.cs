using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;

    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position,
                target.position,
                GuardBT.speed * Time.deltaTime);
            // _transform.LookAt(target.position);

            Vector2 aimDirection = target.position - _transform.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            _transform.rotation = Quaternion.Euler(new Vector3(0, 0, aimAngle));
        }

        state = NodeState.RUNNING;
        return state;
    }

}