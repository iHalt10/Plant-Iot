using System;
/// <summary>
/// ネットワーククラス
/// </summary>
public class Network_Information
{
    public string MyMachineIPAdress;
    public int MyMachineReceivePort;
    public string ServerIPAdress;
    public int ServerReceivePort;
    public int ServerSendPort;
}
/// <summary>
/// 植物クラス
/// </summary>
public class MachinePlantInformation
{
    public string EndItems;
    public int grocwcnt;
    public DateTime startday;
    public DateTime today;
    public DateTime maxday;
    public int dayscnt;
    public int pixel;
    public string watercheck;
    public int waterCnt = 3;
}
public class ButtonCheck
{
    public bool ENDform;
    public int ActionBtCheck;
}