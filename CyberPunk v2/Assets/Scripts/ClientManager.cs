using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class ClientManager : NetworkManager
{
    // Use this for initialization
    private void Start()
    {
        SetupLocalClient();
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
        new Thread(() =>
        {
            singleton.networkAddress = GetLocalIpAddress();
            singleton.networkPort = 7777;
            singleton.StartClient();
        }).Start();
    }

    public static string GetLocalIpAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
}