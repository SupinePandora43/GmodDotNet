using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

public class GameConsoleWriter : TextWriter
{
    private static GameConsoleWriter instance;
    private uint references;

    public override string NewLine { get => "\n"; }
    public override Encoding Encoding => throw new NotImplementedException();

    [DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
    private static extern void Msg([MarshalAs(UnmanagedType.LPStr)] string msg);

    public override void Write(string value)
    {
        Msg(value);
    }

    public static void Load()
    {
        if (instance == null)
        {
            instance = new GameConsoleWriter();
            Console.SetOut(instance);
        }
        instance.references++;
    }
    public static void Unload()
    {
        if (instance != null)
        {
            instance.references--;
            if (instance.references <= 0)
            {
                instance = null;
            }
        }
    }
}
