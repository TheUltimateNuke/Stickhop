using UnityEngine;

public class RagdollFollowControl : MonoBehaviour
{
    [Header("References")]
    public BaseCharacterSetup setupScript;

    private Transform master;
    private Transform ragdoll;

    private Transform[] ragdollTransforms;
    private Transform[] masterTransforms;

    private Transform[] ragdollRigidTransforms;
    private Transform[] masterRigidTransforms;
    private Vector2[] rigidbodiesPosToCOM;

    private HingeJoint2D[] ragdollJoints;
    private float[] targetRotations;

    private int numOfRigids;

    private void Start()
    {
        master = setupScript.masterRoot;
        ragdoll = setupScript.ragdollRoot;

        ragdollTransforms = ragdoll.GetComponentsInChildren<Transform>();
        masterTransforms = master.GetComponentsInChildren<Transform>();

        if (masterTransforms.Length != ragdollTransforms.Length)
        {
            Debug.LogWarning("Master transform count does not equal ragdoll transform count." + "\n");
            return;
        }

        numOfRigids = ragdoll.GetComponentsInChildren<Rigidbody2D>().Length;
        ragdollRigidTransforms = new Transform[numOfRigids];
        masterRigidTransforms = new Transform[numOfRigids];
        rigidbodiesPosToCOM = new Vector2[numOfRigids];
        ragdollJoints = new HingeJoint2D[numOfRigids];
        targetRotations = new float[numOfRigids];

        int i = 0, j = 0;
        foreach (Transform t in ragdollTransforms)
        {
            if (t.GetComponent<Rigidbody2D>())
            {
                ragdollRigidTransforms[i] = t;
                masterRigidTransforms[i] = masterTransforms[j];
                rigidbodiesPosToCOM[i] = Quaternion.Inverse(t.rotation) * (t.GetComponent<Rigidbody2D>().worldCenterOfMass - new Vector2(t.position.x, t.position.y));

                HingeJoint2D hj = t.GetComponent<HingeJoint2D>();
                if (hj != null)
                {
                    ragdollJoints[i] = hj;

                    t.gameObject.AddComponent<RagdollCollisionReporter>();
                }
            }
        }
    }
}