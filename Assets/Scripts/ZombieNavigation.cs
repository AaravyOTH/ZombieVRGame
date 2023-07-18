using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent zombie;
    bool inDelay = true;

    private void Start()
    {
        if (player == null || zombie == null)
        {
            Debug.LogError("Player or Zombie reference is not assigned!");
            return;
        }

        Invoke("SetAgentDestination", 5);
        zombie.Warp(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));

    }

    private void Update()
    {
        if (!inDelay)
        {
            zombie.SetDestination(player.transform.position);
        }
    }

    private void SetAgentDestination()
    {
        inDelay = false;
    }
}
