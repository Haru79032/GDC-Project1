using System;
using UnityEngine;

public static class EventBroker
{
    #region COLLISION CHECK
    public static Action<Collider2D> somethingIsShot;
    public static Action<Collider2D> somethingIsBlocked;
    public static Action<Collider2D> onBulletHitSomething;
    public static Action<Vector3> onBombDeath;
    public static Action<Collider2D> onEnemyHitPlayer;
    #endregion

    #region OUT OF SCREEN CHECK
    public static Action<Collider2D> onBulletOutOfScreen;
    public static Action<Collider2D> onFragmentOutOfScreen;
    public static Action<Collider2D> onEnemyReachedTarget;
    #endregion

    #region MAIN GAMELOOP EVENTS
    public static Action OnDifficultyEnhanced;
    public static Action onGameOver;
    public static Action onGameRestarted;
    #endregion
}