using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    private UnitSO unitStat;

    private float _movementSpeed;
    private float _attackPoint;
    private float _healthPoint;

    public float MovementSpeed => _movementSpeed;
    public float AttackPoint => _attackPoint;
    public float HealthPoint => _healthPoint;
    
    public enum EAnimState { None, Idle, Move, Cast, Die, }
    
    private EAnimState _animState;
    public EAnimState AnimState
    {
        get => _animState;
        set => SetAnimState(value);
    }

    public event UnityAction<EAnimState> onChangedAnimState;
    public event UnityAction moveUpdateCallback;

    [SerializeField]
    protected Animator animator;

    protected virtual void StartIdle()
    {
        animator.CrossFade("Idle", 0.1f);
    }
    
    protected virtual void StartMove()
    {
        animator.CrossFade("Move", 0.1f);
    }

    protected virtual void StartDie()
    {
        animator.CrossFade("Die", 0.1f);
    }

    protected virtual void StartCast()
    {
        
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
                moveUpdateCallback?.Invoke();
            break;
            case EAnimState.Cast:
                UpdateCast();
            break;
            case EAnimState.Die:
                UpdateDie();
            break;
        }

        
    }

    private void SetAnimState(EAnimState state)
    {
        switch (state)
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
        
        _animState = state;
        
        onChangedAnimState?.Invoke(state);

        
    }

    public void TakeDamage(float damage)
    {
        _healthPoint -= damage;
        Debug.Log($"hit! {gameObject.name} {_healthPoint}");
        if (_healthPoint <= 0)
        {
            Debug.Log($"die! {gameObject.name} {_healthPoint}");
            AnimState = EAnimState.Die;
        }
    }

}