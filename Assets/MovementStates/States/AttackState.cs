using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Attacking", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        ExitState(movement, movement.Idle);
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Attacking", false);
        movement.SwitchState(state);
    }
}
