using Mirror;
public abstract class Entity : NetworkBehaviour
{
    public bool CanAttack { get; set; }

    [SyncVar] protected int _health;
    public int Health
    {
        get => _health;
        set { _health = Health; }
    }
    [SyncVar] protected int _damage;
    public int Damage
    {
        get => _damage;
        set => _damage = Damage;
    }
    [SyncVar] protected bool _isMonarch;
    public bool Monarch
    {
        get => _isMonarch;
        set => _isMonarch = Monarch;
    }
    [SyncVar] protected bool _isLethal;
    public bool Lethal
    {
        get => _isLethal;
        set => _isLethal = Lethal;
    }
    [SyncVar] protected bool _isKingpin;
    public bool Kingpin
    {
        get => _isKingpin;
        set => _isKingpin = Kingpin;
    }
    [SyncVar] protected bool _isFeint;
    public bool Feint
    {
        get => _isFeint;
        set => _isFeint = Feint;
    }
    [SyncVar] protected bool _isQuick;
    public bool Quick
    {
        get => _isQuick;
        set => _isQuick = Quick;
    }
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
        targetEntity.TakeDamage(Damage);
        TakeDamage(target.Damage);
    }

    public abstract void OnDeath();
}
