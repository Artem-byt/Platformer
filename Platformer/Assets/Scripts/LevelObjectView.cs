using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class LevelObjectView : MonoBehaviour
    {
        [SerializeField] private Transform _transformOfObject;
        [SerializeField] private SpriteRenderer _spriteRendererOfObject;
        [SerializeField] private Collider2D _colliderOfObject;
        [SerializeField] private Rigidbody2D _rigidbodyOfObject;
        [SerializeField] private int _force;

        private bool _isGrounded = true;

        public Transform TransformOfObject { get => _transformOfObject; }
        public SpriteRenderer SpriteRendererOfObject { get => _spriteRendererOfObject; }
        public Collider2D ColliderOfObject { get => _colliderOfObject; }
        public Rigidbody2D Rigidbody2DOfObject { get => _rigidbodyOfObject; }
        public int Force { get => _force; }
        public bool IsGrounded { get => _isGrounded; }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _isGrounded = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _isGrounded = true;
        }

    }
}

