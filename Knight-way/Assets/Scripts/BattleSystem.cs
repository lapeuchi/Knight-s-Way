using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private List<Unit> _units; // 현재 전투에 참여 중인 모든 유닛 (정렬됨)

    // 전투 종료 여부 플래그
    private bool _isBattleEnded = false;

    private void PrepareBattle(List<Unit> unit, List<Unit> enemies)
    {
        // 1. 임시 데이터 생성 (실제 게임에서는 매니저에서 받아오겠죠?)
        List<Unit> units_A = new List<Unit>() { 
            
        };
        List<Unit> units_B = new List<Unit>() { 
            
        };

        // 2. 합치고 스피드 순 정렬 (작성하신 코드)
        _units = units_A
            .Concat(units_B)
            .OrderByDescending(unit => unit.Speed)
            .ToList();

        StartBattle();
    }

    private void StartBattle()
    {
        // 코루틴으로 턴 루프 시작
        StartCoroutine(BattleRoutine());
    }

    // ★ 핵심 로직: 전투 흐름 관리
    private IEnumerator BattleRoutine()
    {
        int roundCount = 1;

        while (!_isBattleEnded)
        {
            Debug.Log($"--- Round {roundCount} 시작 ---");

            // 정렬된 리스트를 순서대로 돌면서 턴 실행
            foreach (var unit in _units)
            {
                // 죽은 유닛은 건너뛰기
                if (unit.IsDead) continue;

                // 전투가 끝났는지 중간 체크 (예: 적 전멸)
                if (CheckWinCondition()) 
                {
                    EndBattle();
                    yield break; // 코루틴 탈출
                }

                // ★ 유닛에게 행동 명령 내리고, 행동이 끝날 때까지 대기(yield return)
                yield return StartCoroutine(unit.TakeTurn());
            }

            roundCount++;
            yield return new WaitForSeconds(1f); // 라운드 간 잠시 대기
        }
    }

    private bool CheckWinCondition()
    {
        // 승패 조건 체크 로직 (여기서는 생략)
        return false; 
    }

    private void EndBattle()
    {
        _isBattleEnded = true;
        Debug.Log("전투 종료!");
    }
}