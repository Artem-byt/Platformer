using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private List<LevelObjectView> _levelObjects;
        [SerializeField] private int _animationSpeed = 30;

        private Controllers _controllers;
        private GamersMap _gamersMap;



        void Start()
        {
            _gamersMap = new GamersMap(_levelObjects);
            _controllers = new Controllers();
            new GameInitialization(_controllers, _gamersMap, _animationSpeed);
            
        }


        void Update()
        {
            _controllers.Execute();
        }
    }
}

