using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float Force = 10f;

    public string targetRigidbodyTag;  // Tag of the Rigidbody to apply force to

    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(targetRigidbodyTag))
        {
            Rigidbody targetRigidbody = FindTargetRigidbody();
            if (targetRigidbody != null)
            {
                // Calculate force direction based on the collision normal
                Vector3 forceDirection = transform.up;  // Adjust this if needed

                // Apply force using the calculated direction and force magnitude
                targetRigidbody.AddForce(forceDirection * Force, ForceMode.Impulse);
            }
        }
    }

    private Rigidbody FindTargetRigidbody()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetRigidbodyTag);
        if (objectsWithTag.Length > 0)
        {
            return objectsWithTag[0].GetComponent<Rigidbody>();
        }

        Debug.LogWarning("No Rigidbody found with the specified tag: " + targetRigidbodyTag);
        return null;
    }
}
