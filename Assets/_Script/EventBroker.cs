using System;
using UnityEngine;

public static class EventBroker
{
    public static Action<Collider2D> somethingIsShot;
    public static Action<Collider2D> onBulletHitSomething;
    public static Action<Collider2D> onBombDeath;
    public static Action<Collider2D> onShockwaveHitSomething;
}