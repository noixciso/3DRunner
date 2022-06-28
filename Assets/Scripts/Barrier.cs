using UnityEngine;

public class Barrier : MonoBehaviour
{
    private int _damage = 1;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
    }
}
