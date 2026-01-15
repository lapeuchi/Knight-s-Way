using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick; 

    public Vector3 MoveDir
    {
        get
        {
            Vector3 moveDir = joystick.Direction;

            return moveDir;
            
        }   
    }

    
}
