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
    public static Action onBulletShot;
    #endregion

    #region OUT OF SCREEN CHECK
    public static Action<Collider2D> onBulletOutOfScreen;
    public static Action<Collider2D> onFragmentOutOfScreen;
    public static Action<Collider2D> onEnemyReachedTarget;
    #endregion

    #region MAIN GAMELOOP EVENTS
    public static Action onDifficultyEnhanced;
    public static Action<int> onTakingDamage;
    public static Action onGameOver;
    public static Action<bool> onGamePaused;
    public static Action onGameRestarted;
    #endregion

    #region POINTER EVENTS
    public static Action<bool> onPointerTriggerLoad;
    public static Action<bool> onPointerOpenGuide;
    public static Action<bool> onPointerCanClick;
    //public static Action<bool> onPointerEnterGame;
    #endregion
}