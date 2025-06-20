using System;

interface IDocument
{
    void Open();
}

class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Word document");
    }
}

class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening PDF document");
    }
}

class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Excel document");
    }
}

abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

class WordFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

class PdfFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

class ExcelFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new ExcelDocument();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocumentFactory factory = new WordFactory();
        IDocument doc = factory.CreateDocument();
        doc.Open();

        factory = new PdfFactory();
        doc = factory.CreateDocument();
        doc.Open();

        factory = new ExcelFactory();
        doc = factory.CreateDocument();
        doc.Open();
    }
}