using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage = 1;
    
    // Update is called once per frame
    private void Update()
    {
        Debug.DrawLine(transform.position, (transform.up + transform.position) * 5);
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player == null) return;
        
        player.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
