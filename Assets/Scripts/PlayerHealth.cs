using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;


public class PlayerHealth : NetworkBehaviour
{
    [SyncVar] public int health = 10;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
            GetComponent<PlayerHealth>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateHealth(this, -1);
        }
    }

    [ServerRpc]
    public void UpdateHealth(PlayerHealth script, int amountToChange)
    {
        script.health += amountToChange;
    }
}
