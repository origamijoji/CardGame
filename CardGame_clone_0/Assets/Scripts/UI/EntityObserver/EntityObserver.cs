using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityObserver: MonoBehaviour
{
    public abstract void OnNotification();
    public virtual void Start()
    {
        EntitySubject.Add(this);
    }
    public virtual void OnDestroy()
    {
        EntitySubject.Remove(this);
    }
}
