using Mirror;
public abstract class Entity : NetworkBehaviour
{
    [SyncVar] protected int _health;
    public int Health
    {
        get => _health;
        set => _health = Health;
    }

    [SyncVar] protected int _damage;
    public int Damage
    {
        get => _damage;
        set => _damage = Damage;
    }
    [SyncVar] protected bool _isMonarch;
    public bool GetMonarch() => _isMonarch;
    [SyncVar] protected bool _isLethal;
    public bool GetLethal() => _isLethal;
    [SyncVar] protected bool _isKingpin;
    public bool GetKingpin() => _isKingpin;
    [SyncVar] protected bool _isFeint;
    public bool GetFeint() => _isFeint;
    [SyncVar] protected bool _isQuick;
    public bool GetQuick() => _isQuick;

    [SyncVar] protected bool _isDualWield;
    public bool DualWield
    {
        get => _isDualWield;
        set => _isDualWield = DualWield;
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
            OnDeath();
        }
    }
    public void Attack(Entity target)
    {
        var targetEntity = target.GetComponent<Entity>();
        targetEntity.TakeDamage(GetDamage());
        TakeDamage(target.GetDamage());
    }

    public abstract void OnDeath();
}
