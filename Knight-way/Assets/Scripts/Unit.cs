using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float _hp;
    [SerializeField]
    private float _atk;
    [SerializeField]
    private float _speed;

    public float Speed => _speed;

    public bool IsDead;
    // 유닛의 행동 로직 (코루틴)
    public IEnumerator TakeTurn()
    {
        Debug.Log($"👉 {name} (속도 {Speed})의 턴!");

        // 여기에 공격, 스킬, 방어 등의 로직이 들어갑니다.
        // 예: 플레이어라면 UI 입력을 기다리고, 적이라면 AI 로직 실행
        
        // 시뮬레이션: 공격 애니메이션 시간(1초) 만큼 대기
        yield return new WaitForSeconds(1.0f); 

        Debug.Log($"{name} 행동 종료.");
    }

}
