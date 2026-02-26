namespace DesignPatterns.Behavioral_Patterns.TemplateMethod;

public abstract class DataExporter
{
    public void Export()
    {
        OpenFile();
        WriteHeader();
        WriteData();
        CloseFile();
    }

    protected abstract void OpenFile();
    protected virtual void WriteHeader() { /* Default implementation */ }
    protected abstract void WriteData();
    protected abstract void CloseFile();
}

public class CsvDataExporter : DataExporter
{
    protected override void OpenFile() { /* CSV-specific logic */ }
    protected override void WriteHeader() { /* CSV Header */ }
    protected override void WriteData() { /* CSV Data */ }
    protected override void CloseFile() { /* close */ }
}

public class JsonDataExporter : DataExporter
{
    protected override void OpenFile() { /* JSON-specific */ }
    protected override void WriteData() { /* JSON Data */ }
    protected override void CloseFile() { /* close */ }
}
