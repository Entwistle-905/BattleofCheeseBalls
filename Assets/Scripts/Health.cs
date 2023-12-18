using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
    NetworkVariable<float> health = new NetworkVariable<float>(100.0f, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    [ServerRpc(RequireOwnership =false)]
    public void TakeDamageServerRpc(float damage, ServerRpcParams RpcParams)
    {
        Debug.Log(RpcParams.Receive.SenderClientId);
        //Debug.Log();
        NetworkObject Obj = NetworkManager.Singleton.ConnectedClients[RpcParams.Receive.SenderClientId].PlayerObject;
        if (Obj.GetComponent<Health>())
        {
            Obj.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health.Value -= damage;
        Debug.Log(health.Value);
        CheckDead();
    }

    private void CheckDead()
    {
        if (health.Value == 0 || health.Value < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        int death = Random.Range(0, 10);
        anim.SetInteger("DeadVer", death);
        anim.SetBool("IsDead", true);
        SFXManager.Instance.PlayDeadSFX();
    }

}
