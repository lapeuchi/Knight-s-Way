using UnityEngine;
using UnityEngine.Events;

public class PlayerUnit : Unit
{
    [SerializeField]
    private PlayerController controller;

    protected override void UpdateCast()
    {
        
    }

    protected override void UpdateDie()
    {
        
    }

    protected override void UpdateIdle()
    {
        if (controller.MoveDir.sqrMagnitude > 0f)
        {
            AnimState = EAnimState.Move;
            return;
        }
    }

    public event UnityAction<Vector2> moveUpdateCallback;
    protected override void UpdateMove()
    {
        Vector3 moveDir = controller.MoveDir;
        if (moveDir.sqrMagnitude <= 0f)
        {
            AnimState = EAnimState.Idle;
            return;
        }
        transform.position += moveDir * MovementSpeed * Time.deltaTime;
  
        moveUpdateCallback.Invoke(moveDir);
    }

}
