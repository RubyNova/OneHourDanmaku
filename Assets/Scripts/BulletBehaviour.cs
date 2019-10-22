using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage = 1;
    
    // Update is called once per frame
    private void Update() => transform.Translate(_moveSpeed * Time.deltaTime * transform.forward);

    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player == null) return;
        
        player.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
