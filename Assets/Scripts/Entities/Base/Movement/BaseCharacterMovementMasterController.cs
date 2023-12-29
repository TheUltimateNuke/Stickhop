// guided by https://github.com/ashleve/ActiveRagdoll/blob/master/Assets/ActiveRagdollScripts/MasterController.cs

using System;
using UnityEngine;

public enum CharacterState
{
    IDLE = 0,
    WALKING = 1,
    RUNNING = 2,
    FALLING = 3
}

/// <summary>
/// Controls static animator and non-physics based locomotion.
/// </summary>
public abstract class BaseCharacterMovementMasterController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BaseCharacterSetup setupScript;
    [Space]

    public bool canMove = true;

    [Header("Modifiers")]
    public float walkSpeed = 3f;
    public float runSpeedModifier = 1.85f;

    [Header("Character-Related")]
    [Tooltip("How far the character will float above the ground.")]
    public float groundFloatDistance = 0.01f;
    [Tooltip("How fast the static animator rig will return to where the ragdoll is.")]
    public float staticAnimatorReturnSpeed = 7.0f;
    [Tooltip("Max distance before the animator is teleported back to the ragdoll.")]
    public float maxPossibleDistanceFromRagdoll = 2.0f;

    [Space]
    public LayerMask groundLayer;

    public float RunSpeed => walkSpeed * runSpeedModifier;

    private float Gravity => Physics2D.gravity.y;
    private bool IsGrounded => Physics2D.OverlapCircle(transform.position, groundFloatDistance, groundLayer) != null;

    /// <summary>
    /// Must be defined differently if inheriting from <see cref="BaseCharacterMovementMasterController"/>.
    /// </summary>
    public virtual CharacterState CurrentCharacterState { get; private set; }

    /// <summary>
    /// Moves the animator. Intended to be called in Update.
    /// </summary>
    /// <param name="right">If this is set to false, the character will move left.</param>
    public virtual void MoveCharacter(bool right = true)
    {
        Vector2 pushBackMovement = CalculatePushBackMovement();
        Vector2 moveDirection = new Vector2(right ? 1 : -1, 0) + pushBackMovement;
    }

    /// <summary>
    /// Causes the animator to jump.
    /// </summary>
    public virtual void JumpCharacter()
    {
        if (!IsGrounded) return;
    }

    private Vector2 CalculatePushBackMovement()
    {
        // TODO: Do this once setup script ref is assigned
        throw new NotImplementedException();
    }
}
