using UnityEngine;

[CreateAssetMenu(fileName = "UnitModel", menuName = "StageDataSO/StageSO", order = 0)]

public class StageSO : ScriptableObject
{
    [SerializeField]
    public MonsterUnit monsterData;

}