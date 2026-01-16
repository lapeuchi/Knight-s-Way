using System.Collections;
using UnityEngine;


public class PlayerUnit : Unit
{
    [SerializeField]
    private PlayerController controller;

    [SerializeField]
    private Skill basicSkill;

    private Vector3 _recentDir;
    public Vector3 RecentDirection => _recentDir;
  
    float _leftCastingTime = -1;
    bool IsCasting => _leftCastingTime > 0;
    protected override void StartIdle()
    {
        base.StartIdle();
    }

    protected override void StartMove()
    {
        base.StartMove();
    }

    protected override void StartCast()
    {
        base.StartCast();
        
        _leftCastingTime = 1f / animator.GetFloat("BasicAttackSpeed");
        
        animator.CrossFade("Attack", 0.1f);
        basicSkill.Cast();
    }
    
    protected override void UpdateCast()
    {
        _leftCastingTime -= Time.deltaTime;

        if (_leftCastingTime <= 0)
        {
            Debug.Log("스킬 캐스팅 종료");
            _leftCastingTime = 0;
            
            AnimState = EAnimState.Idle;
        }
    }

    protected override void UpdateDie()
    {
        
    }

    protected override void UpdateIdle()
    {
        if (IsCasting == false && controller.MoveDir.sqrMagnitude > 0f)
        {
            AnimState = EAnimState.Move;
            return;
        }
        
        // 적이 있을 때 조건문 돌리고 평타 치기
        AnimState = EAnimState.Cast;
    }

    protected override void UpdateMove()
    {
        Vector3 moveDir = controller.MoveDir.normalized;
        if (moveDir.sqrMagnitude <= 0f)
        {
            AnimState = EAnimState.Idle;
           
            return;
        }

        transform.position += moveDir * MovementSpeed * Time.deltaTime;

        _recentDir = moveDir;
    }

}
