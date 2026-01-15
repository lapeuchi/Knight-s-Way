using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private PlayerUnit playerModel;
    private MonsterUnit mobModel;

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
            // mobModel.hp -= playerModel.hp;
        }

        if (mobAttackable)
        {
            // playerModel.hp -= mobModel.hp;
        }
    }

    private void SetAttack()
    {

    }
}