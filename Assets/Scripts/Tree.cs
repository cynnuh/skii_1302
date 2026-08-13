using UnityEngine;

public class Tree : MonoBehaviour
{
    private MeshRenderer rd;
    private Color originalColor;

    void Start()
    {
        rd = GetComponent<MeshRenderer>();
        originalColor = rd.material.color;
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        rd.material.color = Color.red;

        Player player = collision.gameObject.GetComponent<Player>();

        if (player == null)
            return;

        player.HP -= 15;
        UIManager.instance.ShowNotiText($"Hurt -15\nHP: {player.HP}");

        if (player.HP <= 0)
        {
            player.HP = 0;
         
            UIManager.instance.ShowNotiText($"You are dead!\nPoints: {player.Point}");
            Time.timeScale = 0f;
            UIManager.instance.ShowHideRestartButton(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rd.material.color = originalColor;
    }
}