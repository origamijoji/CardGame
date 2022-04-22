using Mirror;
using UnityEngine;

public abstract class Entity : NetworkBehaviour
{
    public bool CanAttack { get; set; }

    [SyncVar] public int Health;
    [SyncVar] public int Damage;

    [SyncVar] public bool IsMonarch;
    [Command(requiresAuthority = false)] public void SetMonarch(bool value) => IsMonarch = value;
    [SyncVar] public bool IsLethal;
    [Command(requiresAuthority = false)] public void SetLethal(bool value) => IsLethal = value;
    [SyncVar] public bool IsKingpin;
    [Command(requiresAuthority = false)] public void SetKingpin(bool value) => IsKingpin = value;
    [SyncVar] public bool IsFeint;
    [Command(requiresAuthority = false)] public void SetFeint(bool value) => IsFeint = value;
    [SyncVar] public bool IsQuick;
    [Command(requiresAuthority = false)] public void SetQuick(bool value) => IsQuick = value;
    [SyncVar] public bool IsDualWield;
    [Command(requiresAuthority = false)] public void SetDualWield(bool value) => IsDualWield = value;
    [SyncVar] public bool CanAttackAgain;
    [Command(requiresAuthority = false)] public void SetCanAttackAgain(bool value) => CanAttackAgain = value;

    [Command(requiresAuthority = false)]
    public void TakeDamage(int damage)
    {
        if(IsFeint)
        {
            SetFeint(false);
            return;
        }
        Health -= damage;
        Debug.Log($"Taken {damage} damage");
        if (Health <= 0)
        {
            OnDeath();
        }
    }

    public void Attack(Entity target)
    {
        GameManager.Instance.CmdAttackEntity(this, target);
        if(CanAttackAgain)
        {
            CanAttack = true;
            SetCanAttackAgain(false);
        }
    }

    public abstract void OnDeath();
}
