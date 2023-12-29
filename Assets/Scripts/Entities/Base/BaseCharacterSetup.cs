// credit: https://github.com/ashleve/ActiveRagdoll/blob/master/Assets/ActiveRagdollScripts/HumanoidSetUp.cs

using System;
using UnityEngine;

/// <summary>
/// Setup variables applicable for all physics-based character types in Stickhop.
/// </summary>
public class BaseCharacterSetup : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Static animator root GameObject.")]
    public Transform masterRoot;
    [Tooltip("Ragdoll root GameObject.")]
    public Transform ragdollRoot;

    // Automatically assigned variables.
    [NonSerialized] public BaseCharacterMovementMasterController masterController;
    [NonSerialized] public BaseCharacterMovementRagdollController ragdollController;
    [NonSerialized] public RagdollFollowControl ragdollControl;
    // TODO: add Animator reference.

    private void Awake()
    {
        if (masterRoot == null) Debug.LogError(nameof(masterRoot) + " not assigned.");
        if (ragdollRoot == null) Debug.LogError(nameof(ragdollRoot) + " not assigned.");

        masterController = GetComponentInChildren<BaseCharacterMovementMasterController>();
        if (masterController == null) Debug.LogError(nameof(masterController) + " could not be found.");

        ragdollController = GetComponentInChildren<BaseCharacterMovementRagdollController>();
        if (ragdollController == null) Debug.LogError(nameof(ragdollController) + " could not be found.");

        ragdollControl = GetComponentInChildren<RagdollFollowControl>();
        if (ragdollControl == null) Debug.LogError(nameof(ragdollControl) + " could not be found.");

        // TODO: add Animator reference.
    }
}

