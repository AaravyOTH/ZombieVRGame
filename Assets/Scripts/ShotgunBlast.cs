using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class ShotgunBlast : MonoBehaviour
{
    public Transform shotSpawn; // The position where shots will be spawned
    public GameObject shotPrefab; // Prefab of the shot object
    public float shotForce = 10f; // Force applied to the shots
    public float bulletSpread = 0.1f; // Random bullet spread

    private bool canShoot = true; // Flag to control shooting delay
    private void Start()
    {
        //shotSpawn.transform.position.z.Equals(shotSpawn.transform.position.z + 2);  
    }
    private void Update()
    {

        // Check for right trigger press
        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed) && triggerPressed)
        {
            // Check if shooting is currently allowed
            if (canShoot)
            {
                // Start coroutine for shotgun burst
                StartCoroutine(ShotgunBurst());
            }
        }
    }

    private IEnumerator ShotgunBurst()
    {
        // Disable shooting during the burst
        canShoot = false;

        // Spawn 5 shots with random spread
        for (int i = 0; i < 5; i++)
        {
            // Calculate random spread direction
            Vector3 spreadDirection = Random.insideUnitSphere * bulletSpread;

            // Instantiate the shot prefab
            GameObject shot = Instantiate(shotPrefab, shotSpawn.position, Quaternion.identity);

            // Apply force to the shot in the direction the shotgun is facing
            shot.GetComponent<Rigidbody>().AddForce((transform.forward + spreadDirection) * shotForce, ForceMode.Impulse);

            // Wait for a short delay between shots
            yield return new WaitForSeconds(0.3f);
        }

        // Wait for the delay before allowing the next burst
        yield return new WaitForSeconds(3f);

        // Enable shooting again
        canShoot = true;
    }
}
