using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private PlayerUnit playerUnit;

    [SerializeField]
    private SpriteRenderer arrowSprite;

    [SerializeField]
    private float fadeSpeed;

    float _targetAlpha;
    float _curAlpha;

    private void Start()
    {
        playerUnit.moveUpdateCallback += OnMoveUpdated;
        playerUnit.onChangedAnimState += Fade;
    }

    private void Update()
    {
        _curAlpha = Mathf.Lerp(_curAlpha, _targetAlpha, fadeSpeed * Time.deltaTime);
        arrowSprite.color = new Color(arrowSprite.color.r, arrowSprite.color.g, arrowSprite.color.b, _curAlpha);
    }

    private void OnMoveUpdated()
    {
        Vector2 dir = playerUnit.RecentDirection;

        // 2. 아크탄젠트로 각도(라디안) 구하고 -> 도(Degree)로 변환
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // 3. Z축 회전 적용
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void Fade(Unit.EAnimState animState)
    {
        if (animState == Unit.EAnimState.Move)
        {
            _targetAlpha = 1;
        }
        else
        {
            _targetAlpha = 0;
        }
    }

    
    
}
