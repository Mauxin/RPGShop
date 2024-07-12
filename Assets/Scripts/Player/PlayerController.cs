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
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private Animator _playerAnimator;
        
        private const string DIRECTION_ANIMATION_KEY = "Direction";
        private const string IDLE_ANIMATION_KEY = "Idle";
        private const int PLAYER_SPEED = 3;
        
        private KeyCode _lastKey = KeyCode.Escape;

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _playerRigidbody.velocity = new Vector2(-PLAYER_SPEED, 0);
                
                if (_lastKey == KeyCode.A) return;
                _playerAnimator.SetInteger(DIRECTION_ANIMATION_KEY, (int) Direction.Left);
                _playerAnimator.SetBool(IDLE_ANIMATION_KEY, false);
                _lastKey = KeyCode.A;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _playerRigidbody.velocity = new Vector2(PLAYER_SPEED, 0);

                if (_lastKey == KeyCode.D) return;
                _playerAnimator.SetInteger(DIRECTION_ANIMATION_KEY, (int)Direction.Right);
                _playerAnimator.SetBool(IDLE_ANIMATION_KEY, false);
                _lastKey = KeyCode.D;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                _playerRigidbody.velocity = new Vector2(0, PLAYER_SPEED);
                
                if (_lastKey == KeyCode.W) return;
                _playerAnimator.SetInteger(DIRECTION_ANIMATION_KEY, (int) Direction.Up);
                _playerAnimator.SetBool(IDLE_ANIMATION_KEY, false);
                _lastKey = KeyCode.W;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _playerRigidbody.velocity = new Vector2(0, -PLAYER_SPEED);
                
                if (_lastKey == KeyCode.S) return;
                _playerAnimator.SetInteger(DIRECTION_ANIMATION_KEY, (int) Direction.Down);
                _playerAnimator.SetBool(IDLE_ANIMATION_KEY, false);
                _lastKey = KeyCode.S;
            }
            else
            {
                _playerAnimator.SetBool(IDLE_ANIMATION_KEY, true);
                _playerRigidbody.velocity = Vector2.zero;
                _lastKey = KeyCode.Escape;
            }  
        }
    }
}
