using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Dependencies"), SerializeField] 
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private ShootingController _shootingController;

    [Header("Bindings"), SerializeField]
    private KeyCode _moveUpKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode _moveDownKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode _moveLeftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _moveRightKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode _shootUpKey = KeyCode.W;
    [SerializeField] private KeyCode _shootDownKey = KeyCode.S;
    [SerializeField] private KeyCode _shootLeftKey = KeyCode.A;
    [SerializeField] private KeyCode _shootRightKey = KeyCode.D;

    private PlayerDirections _moveDirections;
    private PlayerDirections _shootDirections;
    
    // Start is called before the first frame update
    void FixedUpdate()
    {
        var inputVector = Vector2.zero;
        switch (_moveDirections)
        {
            case PlayerDirections.None:
                break;
            case PlayerDirections.Up:
                ApplyUp();
                break;
            case PlayerDirections.Down:
                ApplyDown();
                break;
            case PlayerDirections.Left:
                ApplyLeft();
                break;
            case PlayerDirections.Right:
                ApplyRight();
                break;
            case PlayerDirections.UpLeft:
                ApplyUp();
                ApplyLeft();
                break;
            case PlayerDirections.UpRight:
                ApplyUp();
                ApplyRight();
                break;
            case PlayerDirections.DownLeft:
                ApplyDown();
                ApplyLeft();
                break;
            case PlayerDirections.DownRight:
                ApplyDown();
                ApplyRight();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        _rigidbody.MovePosition((Vector2)_rigidbody.transform.position + (_moveSpeed * Time.fixedDeltaTime * inputVector.normalized));

        void ApplyRight() => inputVector.x = 1;
        void ApplyLeft() => inputVector.x = -1;
        void ApplyDown() => inputVector.y = -1;
        void ApplyUp() => inputVector.y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_moveUpKey) && !Input.GetKey(_moveDownKey)) _moveDirections |= PlayerDirections.Up;
        else _moveDirections &= ~PlayerDirections.Up;

        if (Input.GetKey(_moveDownKey) && !Input.GetKey(_moveUpKey)) _moveDirections |= PlayerDirections.Down;
        else _moveDirections &= ~PlayerDirections.Down;
        
        if (Input.GetKey(_moveLeftKey) && !Input.GetKey(_moveRightKey)) _moveDirections |= PlayerDirections.Left;
        else _moveDirections &= ~PlayerDirections.Left;

        if (Input.GetKey(_moveRightKey) && !Input.GetKey(_moveLeftKey)) _moveDirections |= PlayerDirections.Right;
        else _moveDirections &= ~PlayerDirections.Right;
        
        if (Input.GetKey(_shootUpKey) && !Input.GetKey(_shootDownKey)) _shootDirections |= PlayerDirections.Up;
        else _shootDirections &= ~PlayerDirections.Up;

        if (Input.GetKey(_shootDownKey) && !Input.GetKey(_shootUpKey)) _shootDirections |= PlayerDirections.Down;
        else _shootDirections &= ~PlayerDirections.Down;
        
        if (Input.GetKey(_shootLeftKey) && !Input.GetKey(_shootRightKey)) _shootDirections |= PlayerDirections.Right;
        else _shootDirections &= ~PlayerDirections.Right;

        if (Input.GetKey(_shootRightKey) && !Input.GetKey(_shootLeftKey)) _shootDirections |= PlayerDirections.Right;
        else _shootDirections &= ~PlayerDirections.Right;
    }
}