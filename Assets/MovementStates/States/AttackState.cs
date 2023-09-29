using System.Collections;
using UnityEngine;

public class AttackState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Attacking", true);
        movement.StartCoroutine(ExitStateCoroutine(movement, movement.Idle));
    }
    
    public override void UpdateState(MovementStateManager movement) { }

    IEnumerator ExitStateCoroutine(MovementStateManager movement, MovementBaseState state)
    {
        //yield return new WaitForSeconds(movement.anim.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(0.5f);

        movement.anim.SetBool("Attacking", false);
        movement.SwitchState(state);
    }
}
