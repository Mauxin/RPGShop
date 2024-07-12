using UnityEngine;

namespace Player
{
    public enum Direction
    {
        Down = 0,
        Up = 1,
        Right = 2,
        Left = 3
    }
    
    public class PlayerController : MonoBehaviour
    {
        private const string DirectionAnimationKey = "Direction";
        private const int PlayerSpeed = 3;
        
        private Rigidbody2D _playerRigidbody;
        private Animator _playerAnimator;
        
        private KeyCode _lastKey = KeyCode.Escape;
        
        void Start()
        { 
            _playerAnimator = GetComponent<Animator>(); 
            _playerRigidbody = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _playerAnimator.speed = 0.5f;
                _playerRigidbody.velocity = new Vector2(-PlayerSpeed, 0);
                
                if (_lastKey == KeyCode.A) return;
                _playerAnimator.SetInteger(DirectionAnimationKey, (int) Direction.Left);
                _lastKey = KeyCode.A;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _playerAnimator.speed = 1;
                _playerRigidbody.velocity = new Vector2(PlayerSpeed, 0);

                if (_lastKey == KeyCode.D) return;
                _playerAnimator.SetInteger(DirectionAnimationKey, (int)Direction.Right);
                _lastKey = KeyCode.D;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                _playerAnimator.speed = 1;
                _playerRigidbody.velocity = new Vector2(0, PlayerSpeed);
                
                if (_lastKey == KeyCode.W) return;
                _playerAnimator.SetInteger(DirectionAnimationKey, (int) Direction.Up);
                _lastKey = KeyCode.W;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _playerAnimator.speed = 1;
                _playerRigidbody.velocity = new Vector2(0, -PlayerSpeed);
                
                if (_lastKey == KeyCode.S) return;
                _playerAnimator.SetInteger(DirectionAnimationKey, (int) Direction.Down);
                _lastKey = KeyCode.S;
            }
            else
            {
                _playerRigidbody.velocity = Vector2.zero;
                _playerAnimator.speed = 0;
            }  
        }
    }
}
