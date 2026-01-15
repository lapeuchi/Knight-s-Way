using UnityEngine;

[CreateAssetMenu(fileName = "UnitModel", menuName = "StageDataSO/UnitSO", order = 0)]
public class UnitSO : ScriptableObject
{
    public float hp;

    public float atk;
    
    public float atkSpeed;
}