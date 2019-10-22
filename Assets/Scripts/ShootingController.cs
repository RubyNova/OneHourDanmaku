using System;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _cooldown = 0.1f;

    private float _currentCooldown;
    public void Shoot(PlayerDirections direction)
    {
        if (_currentCooldown > 0) return;
        _currentCooldown = _cooldown;
        
        var inputVector = Vector2.zero;
        
        switch (direction)
        {
            case PlayerDirections.None:
                return;
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

        var transformCache = transform;
        transformCache.rotation = Quaternion.Euler(inputVector);
        Instantiate(_bulletPrefab, transformCache.position, transformCache.rotation);
        
        void ApplyRight() => inputVector.x = 1;
        void ApplyLeft() => inputVector.x = -1;
        void ApplyDown() => inputVector.y = -1;
        void ApplyUp() => inputVector.y = 1;
    }

    public void Shoot(Vector2 direction)
    {
        var transformCache = transform;
        transformCache.rotation = Quaternion.Euler(direction);
        Instantiate(_bulletPrefab, transformCache.position, transformCache.rotation);
    }

    private void Update() => _currentCooldown -= Time.deltaTime;
}