using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/*public delegate void PlayerAction(InputActionReference action);
public delegate void PlayerActionDirection(InputActionReference moveAction);
public delegate void PlayerActionCameraDirection(InputActionReference cameraAction);
public delegate void PlayerActionSwitch(InputActionReference switchAction);
public interface IPlayerInput
{
    event PlayerAction JumpInput;
    event PlayerActionDirection MoveInput;
    //event PlayerActionCameraDirection CameraMoveInput;
    event PlayerAction ShootInput;
    event PlayerActionSwitch SwitchProjectileInput;
    event PlayerAction WindJumpInput;
    event PlayerAction FlameDashInput;
}*/
public delegate void EnemyActions();
public delegate void EnemyMovePattern(Vector3 direction);
//public delegate void EnemyFollowTarget(Transform target);
public interface IEnemy
{
    event EnemyActions Shoot;
    event EnemyMovePattern Move;
   // event EnemyFollowTarget FollowPlayer;
    event EnemyActions Aim;
    Projectile Resistance { get; }
    Projectile Weakness { get; }
}
public interface IHealth
{
    int MaxHealth { get; }
    void TakeDamage(int pDamage);
}