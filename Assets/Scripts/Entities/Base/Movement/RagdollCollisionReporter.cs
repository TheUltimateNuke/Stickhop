using UnityEngine;


public class RagdollCollisionReporter : MonoBehaviour
{
    private BaseCharacterMovementRagdollController slaveController;

    void Start()
    {
        BaseCharacterSetup setUp = this.GetComponentInParent<BaseCharacterSetup>();
        slaveController = setUp.ragdollController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        slaveController.currentNumberOfCollisions++;
    }

    private void OnCollisionExit(Collision collision)
    {
        slaveController.currentNumberOfCollisions--;
    }

}
