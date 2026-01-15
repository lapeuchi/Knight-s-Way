using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    private UnitSO unitStat;

    private float _movementSpeed;
    private float _attackSpeed;
    private float _attackPoint;
    private float _healthPoint;

    public float MovementSpeed => _movementSpeed;
    public float AttackSpeed => _attackSpeed;
    public float AttackPoint => _attackPoint;
    public float HealthPoint => _healthPoint;
    
    public enum EAnimState { None, Idle, Move, Cast, Die, }
    
    private EAnimState _animState;
    public EAnimState AnimState
    {
        get => _animState;
        set
        {
            switch (value)
            {
                case EAnimState.Idle:
                    StartIdle();
                break;
                case EAnimState.Move:
                    StartMove();
                break;
                case EAnimState.Cast:
                    StartCast();
                break;
                case EAnimState.Die:
                    StartDie();
                break;
            }

            onChangedAnimState.Invoke(value);

            _animState = value;
        }
    }

    public event UnityAction<EAnimState> onChangedAnimState;

    [SerializeField]
    private Animator anim;

    protected virtual void StartIdle()
    {
        anim.CrossFade("Idle", 0.1f);
    }
    
    protected virtual void StartMove()
    {
        anim.CrossFade("Move", 0.1f);
    }

    protected virtual void StartDie()
    {
        anim.CrossFade("Die", 0.1f);
    }

    protected virtual void StartCast()
    {
        anim.CrossFade("Attack", 0.1f);
    }

    protected abstract void UpdateIdle();    

    protected abstract void UpdateMove();

    protected abstract void UpdateCast();

    protected abstract void UpdateDie();


    protected virtual void Awake()
    {
        _movementSpeed = unitStat.movementSpeed;
        _healthPoint = unitStat.hp;
        _attackPoint = unitStat.atk;
        _attackSpeed = unitStat.atkSpd;

        AnimState = EAnimState.Idle;
    }
    
    protected virtual void Update()
    { 
        switch (AnimState)
        {
            case EAnimState.Idle:
                UpdateIdle();
            break;
            case EAnimState.Move:
                UpdateMove();
            break;
            case EAnimState.Cast:
                UpdateCast();
            break;
            case EAnimState.Die:
                UpdateDie();
            break;
        }
        
    }

    


}