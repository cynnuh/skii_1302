using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player == null)
            return;

        player.Point += 10;

        UIManager.instance.ShowNotiText($"+10 points!\nPoints: {player.Point}", Color.yellow);
        Destroy(gameObject);

    }

}