using System;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _cooldown = 0.1f;

    public bool IsReady => _currentCooldown <= 0;

    private float _currentCooldown;
    public void Shoot(PlayerDirections direction)
    {
        if (!IsReady) return;
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
        }
        var transformCache = transform;
        LookAt2d(inputVector);
        var bla = Instantiate(_bulletPrefab, transformCache.position, transformCache.rotation);
        
        void ApplyRight() => inputVector.x = 1;
        void ApplyLeft() => inputVector.x = -1;
        void ApplyDown() => inputVector.y = -1;
        void ApplyUp() => inputVector.y = 1;
    }

    public void Shoot(IEnumerable<float> directions)
    {
        if (!IsReady) return;
        _currentCooldown = _cooldown;
        
        var transformCache = transform;
        foreach (var angle in directions)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(_bulletPrefab, transformCache.position, transformCache.rotation);
        }
    }

    private void LookAt2d(Vector2 dir)
    {
        transform.up = dir;
/*        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        print(transform.rotation);
        Debug.DrawLine(transform.position, (transform.up + transform.position) * 5);*/
    }

    private void Update() => _currentCooldown -= Time.deltaTime;
}