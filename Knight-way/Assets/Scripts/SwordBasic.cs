using UnityEngine;

public class SwordBasic : Skill
{
    [Header("Settings")]
    public float radius = 3f;
    [Range(0, 360)]
    public float viewAngle = 180f;

    private LayerMask _targetLayer;

    private void Start()
    {
        _targetLayer = LayerMask.GetMask("Monster");
    }

    public override void Cast()
    {
        
        DetectTargets();
    }

    void DetectTargets()
    {
        // 1. 주변 원형 범위 내의 모든 콜라이더 가져오기
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, radius, _targetLayer);
        Debug.Log("cast");
        foreach (Collider2D target in targets)
        {
            Debug.Log("cast2");
            // 타겟의 방향 벡터 (타겟위치 - 내위치)
            Vector2 directionToTarget = (target.transform.position - transform.position).normalized;

            // 2. 내 정면(transform.right)과 타겟 사이의 각도 계산
            float angleToTarget = Vector2.Angle(transform.right, directionToTarget);

            // 3. 시야각 절반 안에 들어오는지 확인
            // (180도 설정 시, 좌우 90도 이내인지 체크)
            if (angleToTarget < viewAngle / 2f)
            {
                Debug.Log($"감지됨: {target.name}");

                target.GetComponent<MonsterUnit>().TakeDamage(10);
            }
        }
    }

    // 에디터에서 범위를 눈으로 보기 위한 기즈모 그리기
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // 전체 원 그리기
        Gizmos.DrawWireSphere(transform.position, radius);

        // 부채꼴 라인 그리기
        Vector3 rightDir = AngleToDir(-viewAngle / 2);
        Vector3 leftDir = AngleToDir(viewAngle / 2);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + rightDir * radius);
        Gizmos.DrawLine(transform.position, transform.position + leftDir * radius);
    }

    // 각도를 벡터로 변환하는 헬퍼 함수
    private Vector3 AngleToDir(float angleInDegrees)
    {
        // 현재 내 회전값(Z축)을 더해서 로컬 회전 반영
        float totalAngle = angleInDegrees + transform.eulerAngles.z;
        
        // 라디안 변환 후 코사인/사인으로 벡터 계산
        return new Vector3(Mathf.Cos(totalAngle * Mathf.Deg2Rad), Mathf.Sin(totalAngle * Mathf.Deg2Rad), 0);
    }

    
}