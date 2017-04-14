using System;
using System.Drawing;
using System.IO;
public class ComboBoxCustomItem
{
    public string text;
    public string dir;
    public int fileCount;

    public override string ToString()
    {
        return text;
    }

}
public class Plant_TestItems
{
    int ItemsNumber;
    public ComboBoxCustomItem[] Add = new ComboBoxCustomItem[1];
    public Plant_TestItems(string stPlanttestDir)
    {
        ItemsNumber = Directory.GetDirectories(stPlanttestDir).Length + 1;
        Array.Resize<ComboBoxCustomItem>(ref Add, ItemsNumber);

        Add[0] = new ComboBoxCustomItem();
        Add[0].text = "選択されていません";
        Add[0].dir = null;
        Add[0].fileCount = 0;
        for (int i = 1; i < ItemsNumber; i++)
        {
            Add[i] = new ComboBoxCustomItem();
            Add[i].text = "テスト(" + i.ToString() + ")";
            Add[i].dir = stPlanttestDir + Add[i].text + "\\";
            Add[i].fileCount = Directory.GetFiles(Add[i].dir, "*", SearchOption.TopDirectoryOnly).Length;
        }
    }
    public int ItemsNum
    {
        get { return ItemsNumber; }
    }
}