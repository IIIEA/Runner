using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private int _maxHeight;
    [SerializeField] private int _minHeight;

    private Vector3 _targetPosition;

    private void Awake()
    {
        _targetPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (gameObject.transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize);
    }
}
