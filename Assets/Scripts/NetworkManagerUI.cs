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

    private void Awake()
    {
        HostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            this.gameObject.SetActive(false);
            BG2.gameObject.SetActive(true);
            RedInfo.gameObject.SetActive(true);
            BlueInfo.gameObject.SetActive(true);
        });

        ClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            this.gameObject.SetActive(false);
            BG2.gameObject.SetActive(true);
            RedInfo.gameObject.SetActive(true);
            BlueInfo.gameObject.SetActive(true);
        });
    }
}
