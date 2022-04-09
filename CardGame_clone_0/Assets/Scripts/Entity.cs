using Mirror;
public abstract class Entity : NetworkBehaviour
{
    [SyncVar] public int _health;
    [SyncVar] public int _damage;

    public int GetDamage() {
        return _damage;
    }
    public int GetHealth() {
        return _health;
    }
    public void TakeDamage(int damage) {
        _health -= damage;
        if(_health <= 0) {
            Destroy(gameObject);
            OnDeath();
        }
    }
    public abstract void OnDeath();
}
