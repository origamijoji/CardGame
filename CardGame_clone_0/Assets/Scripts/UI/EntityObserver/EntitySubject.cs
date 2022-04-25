using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntitySubject
{
    private static List<EntityObserver> s_observers = new List<EntityObserver>();

    public static void Add(EntityObserver newObserver, bool notify = true)
    {
        s_observers.Add(newObserver);
        if (notify) Notify();
    }

    public static void Remove(EntityObserver observer)
    {
        s_observers.Remove(observer);
    }

    public static void Notify()
    {
        foreach(EntityObserver observer in s_observers)
        {
            observer.OnNotification();
        }
    }
}
