using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class PlayerMoveController
    {
        private LevelObjectView _levelObjectView;
        private int _animationSpeed;
        private SpriteAnimatorController _playerAnimator;

        public PlayerMoveController(MoveInputController moveInputController, LevelObjectView levelObjectView, int animationSpeed, SpriteAnimatorController spriteAnimatorController)
        {
            _playerAnimator = spriteAnimatorController;
            _animationSpeed = animationSpeed;
            _levelObjectView = levelObjectView;
            moveInputController.MoveRight += MovePlayerRight;
            moveInputController.Idle += PlayerIdle;
            moveInputController.Jump += MovePlayerJump;
            moveInputController.MoveLeft += MovePlayerLeft;
        }

        public void PlayerIdle(bool isIdle)
        {
            if (isIdle)
            {
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Idle, true, _animationSpeed);
            }
        }

        private void MovePlayerRight(bool goingRight)
        {
            
            if (goingRight)
            {
                var transform = _levelObjectView.TransformOfObject.localScale = new Vector3(1, 1, 1);
                transform.x = 1f;
                _levelObjectView.Rigidbody2DOfObject.AddForce(Vector3.right);
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Run, true, _animationSpeed);
            }
        }

        private void MovePlayerLeft(bool goingLeft)
        {

            if (goingLeft)
            {
                _levelObjectView.TransformOfObject.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                _levelObjectView.Rigidbody2DOfObject.AddForce(Vector3.left);
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Run, true, _animationSpeed);
            }
        }


        private void MovePlayerJump(bool isJump)
        {

            if (isJump && _levelObjectView.IsGrounded)
            {
                _levelObjectView.Rigidbody2DOfObject.AddForce(Vector3.up * _levelObjectView.Force, ForceMode2D.Impulse);
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Jump, true, _animationSpeed);
            }
        }
    }
}

