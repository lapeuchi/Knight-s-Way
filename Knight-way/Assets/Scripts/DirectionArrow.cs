using System.Collections;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private PlayerUnit player;

    private void Start()
    {
        player.moveUpdateCallback += OnMove;
        player.onChangedAnimState += Fade;
    }

    private void OnMove(Vector2 dir)
    {
        // 2. 아크탄젠트로 각도(라디안) 구하고 -> 도(Degree)로 변환
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // 3. Z축 회전 적용
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void Fade(Unit.EAnimState animState)
    {
        if (animState == Unit.EAnimState.Move)
        {
            
        }
        else
        {
            
        }
    }

    private Coroutine coFade;
    private float fadeSpeed = 2f;
    private IEnumerator CoFadeIn()
    {
        Color color = new Color(1,1,1,1);
       
        while (color.a > 0)
        {
            color.a -= 2f * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator CoFadeOut()
    {
        Color color = new Color(1,1,1,0);
   
        while (color.a < 1)
        {
            
            yield return null;
        }
    }
    
}
