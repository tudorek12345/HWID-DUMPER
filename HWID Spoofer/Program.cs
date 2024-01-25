using System;
using System.Management;
using System.IO;
using System.Threading;

class HardwareInfo
{
    static void Main()
    {
        // Starting
        Console.WriteLine("If you're having any problems running this program, RUN IT AS AN ADMINISTRATOR !!!");
        Thread.Sleep(2000);
        Console.WriteLine("Welcome to a program that will look up your HWID such as CPU,GPU,Memory,HDD/SSD");
        Console.WriteLine("Made by Joe Vanek");
        Console.WriteLine("Coded in C#");
        Thread.Sleep(2000);
        Console.WriteLine("Retrieving Hardware IDs...");
        Thread.Sleep(1000);
        Console.WriteLine("...");
        Thread.Sleep(1000);
        Console.WriteLine(".......");
        Thread.Sleep(2000);
        Console.WriteLine("............");
        Thread.Sleep(1000);
        Console.WriteLine("....................");



        // Retrieving Hardware ID's
        // Hardware ID's get stored into strings
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string videoControllerInfo = GetHardwareID("Win32_VideoController", "Name", "DeviceID");
        string processorInfo = GetHardwareID("Win32_Processor", "Name", "ProcessorId");
        string memoryInfo = GetHardwareID("Win32_PhysicalMemory", "Name", "DeviceLocator");
        string hardDiskInfo = GetHardwareID("Win32_DiskDrive", "Name", "Model");
        // create more strings to GetHardwareID for other hardware components...................................

        // Dumping Hardware Info initiation
        Console.WriteLine("Type the keyword " + "DUMP" + " to dump hardware info onto the desktop");
        if (Console.ReadLine() == ("DUMP")) // jaaa
        {
            //UNUSED CODE BELOW {InGreen}
            //Console.WriteLine("Your Processor " + processorInfo); // shows Processor Info from string
            //Console.WriteLine("Your Graphics Card " + videoControllerInfo); // shows GPU Info from string
            //Console.WriteLine("Your Hard Drive " + hardDiskInfo); // shows Hard Disk Info from string
            //Console.WriteLine("Your Memory " + memoryInfo); // shows Memory Info from string
            // Write the information to a text file on the desktop

            //Dumping Hardware Info process
            File.WriteAllText(Path.Combine(desktopPath, "hardware_info.txt"),
                // naming the file "hardware_info"
                // including the hardware ID's
                $"Your GPU Information:\n{videoControllerInfo}\n" +
                $"Your CPU Information:\n{processorInfo}\n" +
                $"Your Memory Information:\n{memoryInfo}\n" +
                $"Your Hard Disk Information:\n{hardDiskInfo}");
        }
        // success?
        Console.WriteLine("Your Hardware Information Has been successfuly dumped onto your desktop");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    // Getting HardwareID's
    static string GetHardwareID(string hwClass, string nameProperty, string idProperty)
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT {nameProperty}, {idProperty} FROM {hwClass}");

        string info = $"Hardware Info - {hwClass}:\n";
        foreach (var obj in searcher.Get())
        {
            info += $"  {nameProperty}: {obj[nameProperty]}\n";
            info += $"  {idProperty}: {obj[idProperty]}\n\n";
        }
        return info;
    }
}


