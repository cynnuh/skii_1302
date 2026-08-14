using UnityEngine;

public class Tree : MonoBehaviour
{
    private MeshRenderer rd;
    private Color[] originalColors;

    void Start()
    {
        rd = GetComponentInChildren<MeshRenderer>();
        originalColors = new Color[rd.materials.Length];
        for (int i = 0; i < rd.materials.Length; i++)
        {
            originalColors[i] = rd.materials[i].color;
        }
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Material m in rd.materials)
        {
            m.color = Color.red;
        }

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
        for (int i = 0; i < rd.materials.Length; i++)
        {
            rd.materials[i].color = originalColors[i];
        }
    }
}