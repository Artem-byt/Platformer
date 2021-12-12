using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private int _animationSpeed = 30;

        private SpriteAnimatorController _playerAnimator;
        private MoveInputController _moveInputController;
        private PlayerMoveController _playerMoveController;



        void Start()
        {
            
            _moveInputController = new MoveInputController();
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("SpriteAnimationConfig");

            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerMoveController = new PlayerMoveController(_moveInputController, _playerView, _animationSpeed, _playerAnimator);
        }


        void Update()
        {
            _moveInputController.GetMoveInput();
            _playerAnimator.Update();
        }
    }
}

