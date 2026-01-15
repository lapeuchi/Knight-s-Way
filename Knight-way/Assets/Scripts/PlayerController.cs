using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerUnit unit;

    [SerializeField]
    private Joystick joystick;

    private void Update()
    { 
        Vector2 moveDir = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (moveDir.sqrMagnitude > 0f)
        {
            Move(moveDir);
        }
        
    }


    public void Move(Vector3 dir)
    {
        transform.position += dir * unit.MovementSpeed * Time.deltaTime;
    }
}
