using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] Button HostButton;
    [SerializeField] Button ClientButton;

    public GameObject BG2;
    public GameObject RedInfo;
    public GameObject BlueInfo;

    static public bool IsServer = false;
    static public bool IsClientExist = false;

    private void Awake()
    {
        HostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            this.gameObject.SetActive(false);
            BG2.gameObject.SetActive(true);
            RedInfo.gameObject.SetActive(true);
            BlueInfo.gameObject.SetActive(true);
            AudioManager.Instance.PlayBattleMusic();
            IsServer = true;
        });

        ClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            this.gameObject.SetActive(false);
            BG2.gameObject.SetActive(true);
            RedInfo.gameObject.SetActive(true);
            BlueInfo.gameObject.SetActive(true);
            AudioManager.Instance.PlayBattleMusic();
            IsServer = false;
            IsClientExist = true;
        });
    }
}
