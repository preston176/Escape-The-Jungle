using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] private GameObject thePlayer;
    [SerializeField] private GameObject playerAnim;

    void OnTriggerEnter(Collider other)
    {
        if (!GameState.IsPlaying) return;

        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards");

        if (GameState.Instance != null)
        {
            GameState.Instance.TriggerGameOver();
        }
    }
}
