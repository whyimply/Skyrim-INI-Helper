using IniParser;
using IniParser.Model;
using System.Text;

namespace SIH.Features.ManageParameters;

public class Parameter
{
    required public string Name { get; set; }
    required public string Designation { get; set; }
    required public string Section { get; set; }
    required public string MySection { get; set; } 
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

        // убираем пробелы вокруг "="
        parser.Parser.Configuration.AssigmentSpacer = "";

        var data = parser.ReadFile($"{path}\\{SourceFile}", new UTF8Encoding(false));

        CurrentValue = data[Section][Name];
    }

    public void Save(string path, string value)
    {
        CurrentValue = value;
        string filePath = $"{path}\\{SourceFile}";

        var parser = new FileIniDataParser();

        // убираем пробелы вокруг "="
        parser.Parser.Configuration.AssigmentSpacer = "";

        // 1. Читаем существующий файл
        IniData data;
        if (File.Exists(filePath))
        {
            data = parser.ReadFile(filePath);
        }
        else
        {
            data = new IniData();
        }

        // 2. Обновляем значение (или создаём, если нет)
        data[Section][Name] = CurrentValue;

        // 3. Записываем обратно
        parser.WriteFile(filePath, data, new UTF8Encoding(false));
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