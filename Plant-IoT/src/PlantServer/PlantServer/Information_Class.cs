/// <summary>
/// サーバに必要な変数
/// </summary>
public class Server_Information
{
    public bool ENDform;
    public string stLightChangeXmlDir;
    public string stClientDir;
    public string stPlantPicturetDir;
    public string stPlantinfoDir;
    public int grocwcnt;
    public int dayscnt;
    public string startday;
    public string today;
    public int pixel;
    public int watercheck;
    public double lenght;
    public string foldername;
    public string filename;
    public string makefilename;
    public int TwitterCnt;
}
/// <summary>
/// クライアント「PlantClientInformation.xml」に必要な変数　xmlファイルに書き込み
/// </summary>
public class Plant_Client_Information
{
    public int startup = -1;
    public int growcnt = -1;
    public int dayscnt = -1;
    public string startday = "";
    public string today = "";
    public double lenght = -1;
    public string period = "";
    public string light = "";
    public string watercheck = "";
    public string stPictureDir = "";
    public string stPictureGridDir = "";
}
/// <summary>
/// 各植物情報のデータベースに必要な変数　xmlファイルに書き込み
/// </summary>
public class Plant_Information
{
    public string stPictureDir;
    public string stPictureGridDir;
    public string day;
    public string period;
    public string lenght;
    public string light;
    public string watercheck;
}
/// <summary>
/// ネットワークに必要な変数
/// </summary>
public class Network_Information
{
    public string MyServerIPAdress;
    public int MyServerReceivePort;
    public string MachineIPAdress;
    public int MachineReceivePort;
    public int MachineSendPort;
}