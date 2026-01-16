using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick; 

    void Start()
    {
        InputSystem.actions.FindAction("Move").performed += OnMove;
        InputSystem.actions.FindAction("Move").canceled += OnMoveEnd;
    }

    Vector3 inputDir;
    private void OnMove(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }

    private void OnMoveEnd(InputAction.CallbackContext context)
    {
        inputDir = Vector3.zero;
    }

    public Vector3 MoveDir
    {
        get
        {
            Vector3 moveDir = joystick.Direction;
            if (moveDir.sqrMagnitude <= 0)
            {
                moveDir = new Vector3(inputDir.x, inputDir.y, 0);

            }

            return moveDir;
            
        }   
    }

    
}
