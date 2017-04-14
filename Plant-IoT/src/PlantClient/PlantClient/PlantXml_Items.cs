using System;
using System.IO;

/// <summary>
///コンボボックス用クラス
/// </summary>
public class ComboBoxCustomItem
{
    public string text;
    public string dir;

    public override string ToString()
    {
        return text;
    }

}
/// <summary>
///コンボボックスの設定
/// </summary>
public class PlantXml_Items
{
    public ComboBoxCustomItem[] Add = new ComboBoxCustomItem[0];
    public PlantXml_Items(int growcnt)
    {
        string stPlantDir = Directory.GetCurrentDirectory().TrimEnd('c', 'l', 'i', 'e', 'n', 't') + "植物情報\\";
        Array.Resize<ComboBoxCustomItem>(ref Add, growcnt);
        for (int i = 0; i < growcnt; i++)
        {
            Add[i] = new ComboBoxCustomItem();
            Add[i].text = "植物(" + (1 + i).ToString() + ")";
            Add[i].dir = stPlantDir + Add[i].text + ".xml";
        }
    }
}