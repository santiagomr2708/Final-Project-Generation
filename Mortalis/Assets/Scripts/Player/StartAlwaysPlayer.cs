using UnityEngine;

public class StartAlwaysPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 playerPosition;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        playerPosition = transform.position;
        player.transform.position = playerPosition;
    }
}
