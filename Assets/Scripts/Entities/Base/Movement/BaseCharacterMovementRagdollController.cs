using System;
using UnityEngine;

public enum CharacterRagdollState
{
    FOLLOWING_ANIMATION = 0,
    LOSING_STRENGTH = 1,
    GAINING_STRENGTH = 2,
    DEAD = 3
}

/// <summary>
/// Controls ragdoll and physics-based animation following.
/// </summary>
public abstract class BaseCharacterMovementRagdollController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BaseCharacterSetup setupScript;
    [Space]

    [Header("Character-Related")]
    public float loseStrengthLerpMod = 1.0f;
    public float gainStrengthLerpMod = 0.05f;
    public float minContactForce = 0.1f;
    public float minContactTorque = 0.1f;
    public float deathTime = 4.0f;

    public virtual CharacterRagdollState CurrentCharacterRagdollState { get; private set; }

    private RagdollFollowControl ragdollControl;
    private float maxTorqueCoefficient;
    private float maxForceCoefficient;
    private float currentDeadStep;

    private float currentStrength = 1.0f;

    [NonSerialized] public int currentNumberOfCollisions;

    private void Start()
    {
        ragdollControl = setupScript.ragdollControl;

        maxForceCoefficient = 
    }
}
