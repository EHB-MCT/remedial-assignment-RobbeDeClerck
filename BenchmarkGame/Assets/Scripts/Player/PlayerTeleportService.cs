using UnityEngine;

public class PlayerTeleportService
{
    public void TeleportPlayer(Transform spawnPoint)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!player) return;

        var cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        player.transform.position = spawnPoint.position;

        if (cc != null) cc.enabled = true;
    }
}
