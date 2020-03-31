using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private void Update()
    {
        _animator.SetFloat("Speed", 0);
        if (Input.GetKey(KeyCode.D))
        {
            Move(false, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(true, -1);
        }
    }

    private void Move(bool xAnimationFlip, int direction)
    {
        _renderer.flipX = xAnimationFlip;
        _animator.SetFloat("Speed", 1f);
        transform.Translate(new Vector3(_speed * Time.deltaTime * direction, 0, 0));
    }


}
