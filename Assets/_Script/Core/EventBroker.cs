using System;
using UnityEngine;

public static class EventBroker
{
    #region COLLISION CHECK
    public static Action<Collider2D> somethingIsShot;
    public static Action<Collider2D> somethingIsBlocked;
    public static Action<Collider2D> onBulletHitSomething;
    public static Action<Vector3> onBombDeath;
    #endregion

    #region OUT OF SCREEN CHECK
    public static Action<Collider2D> onBulletOutOfScreen;
    public static Action<Collider2D> onFragmentOutOfScreen;
    #endregion
}