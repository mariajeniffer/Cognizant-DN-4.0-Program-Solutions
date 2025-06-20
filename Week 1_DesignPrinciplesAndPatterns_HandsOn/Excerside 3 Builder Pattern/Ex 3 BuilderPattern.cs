using System;

class Computer
{
    private string CPU;
    private string RAM;
    private string Storage;

    private Computer(Builder builder)
    {
        this.CPU = builder.CPU;
        this.RAM = builder.RAM;
        this.Storage = builder.Storage;
    }

    public void ShowSpecs()
    {
        Console.WriteLine("CPU: " + CPU);
        Console.WriteLine("RAM: " + RAM);
        Console.WriteLine("Storage: " + Storage);
    }

    public class Builder
    {
        public string CPU;
        public string RAM;
        public string Storage;

        public Builder SetCPU(string cpu)
        {
            this.CPU = cpu;
            return this;
        }

        public Builder SetRAM(string ram)
        {
            this.RAM = ram;
            return this;
        }

        public Builder SetStorage(string storage)
        {
            this.Storage = storage;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}

class BuilderPatternExample
{
    static void Main(string[] args)
    {
        Computer comp = new Computer.Builder()
            .SetCPU("Intel i7")
            .SetRAM("16GB")
            .SetStorage("512GB SSD")
            .Build();

        comp.ShowSpecs();
    }
}
