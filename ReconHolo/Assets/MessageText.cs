using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MessageText : MonoBehaviour {

    public Transform cameraTf;
    public Transform messageTextTf;
    public TextMesh messageTextTm;
    public TcpClientHandler tcpClientHandler;
    public ThreadCompat threadComp;
    public int count = 0;

    private const String HOST = "192.168.43.228";
    private const String PORT = "8081";
    private bool msgWasInit;
    // Use this for initialization
    void Start () {
        // Positioning text
        // V degrees in the vertical plane and
        float V = 0;// + deflection
        //H degrees in the horizontal plane
        float H = 90;// + deflection
        float distance = 2; //distance from the camera

        Vector3 vTarget = Quaternion.Euler(V, H, 0) * -Vector3.forward;
        messageTextTf.position = cameraTf.position - vTarget * distance;
        threadComp.start(new ThreadCompat.RunFunction(threadFunc));
    }
	
	// Update is called once per frame
	void Update () {
        //msgWasInit = tcpClientHandler.Write("Hello from hololens"+ count);
        //count++;
        //messageTextTm.text = tcpClientHandler.Read();
    }
   
    public void threadFunc()
    {
        String msg;
        tcpClientHandler.Connect(HOST, PORT);
        msgWasInit = tcpClientHandler.Write("mark_target");
        while (msgWasInit)
        {
            try
            {
                msg = tcpClientHandler.Read();
            }
            catch(Exception e)
            {
                return;
            }
            if(msg != null)
            {
                Debug.Log(msg);
            }
        }
        
    }
}
