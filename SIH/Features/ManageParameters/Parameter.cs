using IniParser;
using IniParser.Model;

namespace SIH.Features.ManageParameters;

public class Parameter
{
    required public string Name { get; set; }
    required public string Section { get; set; }
    required public int GlobalPosition { get; set; }
    required public string Type { get; set; }
    required public string[] DescriptionSections { get; set; }
    required public string Warning { get; set; }
    required public string DefaultValue { get; set; }
    required public string CurrentValue { get; set; }
    required public string SourceFile { get; set; }

    required public ValueOption[] ValueOptions { get; set; }

    public void Load(string path)
    {
        var parser = new FileIniDataParser();
        var data = parser.ReadFile($"{path}\\{SourceFile}");

        CurrentValue = data[Section][Name];
    }

    public void Save(string path, string value)
    {
        CurrentValue = value;
        string filePath = $"{path}\\{SourceFile}";

        var parser = new FileIniDataParser();
        var data = new IniData();

        data["Display"]["bFull Screen"] = CurrentValue;

        parser.WriteFile(filePath, data);
    }

    public void RestoreToDefault(string path)
    {
        Save(path, DefaultValue);
    }

    public class ValueOption()
    {
        required public string Value { get; set; }
        required public string Remark { get; set; }
        required public string ScreenshotPath { get; set; }
    }
}