using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private UnitModel playerModel;

    private UnitModel mobModel;

    private void Start()
    {
        
    }
    
    private void Update()
    {
        Attack(); 
    }

    private void Attack()
    {
        bool playerAttackable = false;
        bool mobAttackable = false;
        
        if (playerAttackable)
        {
            mobModel.hp -= playerModel.hp;
        }

        if (mobAttackable)
        {
            playerModel.hp -= mobModel.hp;
        }
    }

    private void SetAttack()
    {

    }
}