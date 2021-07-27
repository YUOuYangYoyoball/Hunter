using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using Valve.VR;
using System.Threading;

public class write : MonoBehaviour
{

    static public char suit='0';
    static public bool GetZero=false;
    public SerialPort serialPort=new SerialPort("COM4", 9600);
    public SteamVR_Action_Vibration hapticAction;
    Thread myThread;
    string value;
    // Start is called before the first frame update
    void Start()
    {
        serialPort.Open();
        Debug.Log("open");
        myThread = new Thread(new ThreadStart(GetArduino)); 
        myThread.Start(); 
        GetZero=false;
    }
    void OnEnable() {
        serialPort.Open();
        Debug.Log("Open again");
    }
   
    // Update is called once per frame
    void Update()
    {
       
       switch(suit)
        {
            case 'a':
            {
                serialPort.Write("1");
                break;
            }
            case 'b':
            {
                serialPort.Write("2");
                break;
            }
           /* case 'c':
            {
                serialPort.Write("3");
                break;
            }*/
            case 'd':
            {
                serialPort.Write("4");
                break;
            }
            case 'e':
            {
                serialPort.Write("5");
                //suit='0';
                // Debug.Log("5");
                break;
            }
            case 'f':
            {
                serialPort.Write("6");
                break;
            }
            case 'g':
            {
                serialPort.Write("7");
                break;
            }
            case '0':
            {
                serialPort.Write("0");
                GetZero=true;
                break;
            }
            
        }
         
        
        if(suit!='0')
        {
            Pulse(1,150,25,SteamVR_Input_Sources.Any);
        }
        Debug.Log("suit"+suit);    
    }
        

    private void GetArduino()
    {
       /*  
        
        while(myThread.IsAlive && serialPort.IsOpen)
        {
            if(suit!='0')
            {
                Pulse(1,150,25,SteamVR_Input_Sources.Any);
            }  
            Debug.Log("suit"+suit);
        }
        /*.if(serialPort.IsOpen)
        {            
            switch(suit)
            {
                case 'a':
                {
                    serialPort.Write("1");
                    //suit='0';
                    //Debug.Log("1");
                    break;
                }
                case 'b':
                {
                    serialPort.Write("2");
                    //suit='0';
                    //Debug.Log("2");
                    break;
                }
                case 'c':
                {
                    serialPort.Write("3");
                    //suit='0';
                    // Debug.Log("3");
                    break;
                }
                case 'd':
                {
                    serialPort.Write("4");
                    //suit='0';
                    // Debug.Log("4");
                    break;
                }
                case 'e':
                {
                    serialPort.Write("5");
                    //suit='0';
                    // Debug.Log("5");
                    break;
                }
                case 'f':
                {
                    serialPort.Write("6");
                    //suit='0';
                    //Debug.Log("6");
                    break;
                }
                case 'g':
                {
                    serialPort.Write("7");
                    //suit='0';
                    //Debug.Log("7");
                    break;
                }
                case '0':
                {
                    serialPort.Write("0");
                    // Debug.Log("0");
                    break;
                }
                
            }
        
        }*/
    }
     void OnDisable() {
       serialPort.Close();
       myThread.Abort();
    }
    void OnApplicationQuit() {
        serialPort.Close();
        myThread.Abort();
    }
    private void Pulse(float duration,float frequency, float amplitude,SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0,duration,frequency,amplitude,source);
    }

    public void Invoko_suit(string data)
    {
        serialPort.Write(data);
        Pulse(1,150,25,SteamVR_Input_Sources.Any);
    }

}