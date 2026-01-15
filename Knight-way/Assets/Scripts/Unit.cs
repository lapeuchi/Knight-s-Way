using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private float hp;
    private float atk;
    private float atkSpd;
    private float movementSpeed = 3;

    public float MovementSpeed => movementSpeed;

    
    public enum EAnimState
    {
        Idle,
        Walk,
        Cast,
        Die,
    }
    
    private EAnimState _animState;
    public EAnimState AnimState
    {
        get => _animState;
        set
        {
            _animState = value;
        }
    }

    [SerializeField]
    private Animator anim;

    public virtual void Attack()
    {
        anim.CrossFade("Attack", 0.1f);
    }

    public virtual void Die()
    {
        anim.CrossFade("Die", 0.1f);
    }

    

    public virtual void Cast()
    {
        
    }


}