using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace GmodNET
{
    /// <summary>
    /// Redirects Console's output to game's console
    /// </summary>
    internal class GameConsoleWriter : TextWriter
    {
        public override string NewLine => "\n";
        public override Encoding Encoding => Encoding.UTF8;

#pragma warning disable CA2101
        [DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Msg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

        public override void Write(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                Msg(value);
            }
        }
        public override void Write(char value)
        {
            Write(value.ToString());
        }
        public override void Write(char[] value)
        {
            Write(new string(value));
        }
        public override void Write(char[] buffer, int index, int count)
        {
            Write(new string(buffer, index, count));
        }
        public override void Write(ReadOnlySpan<char> buffer)
        {
            Write(new string(buffer));
        }
        public override void Write(StringBuilder value)
        {
            if (value != null)
            {
                Write(value.ToString());
            }
        }
        // \n begins here
        public override void WriteLine(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                Write(value + NewLine);
            }
            else
            {
                WriteLine();
            }
        }
        public override void WriteLine(char value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(char[] buffer)
        {
            Write(new string(buffer) + NewLine);
        }
        public override void WriteLine(char[] buffer, int index, int count)
        {
            Write(new string(buffer, index, count) + NewLine);
        }
        public override void WriteLine(ReadOnlySpan<char> buffer)
        {
            Write(new string(buffer) + NewLine);
        }
        public override void WriteLine(StringBuilder value)
        {
            if (value != null)
            {
                Write(value.ToString() + NewLine);
            }
            else
            {
                WriteLine();
            }
        }
        public override void WriteLine(bool value)
        {
            Write((value ? "True" : "False") + NewLine);
        }
        public override void WriteLine(int value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(uint value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(long value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(ulong value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(float value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(double value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(decimal value)
        {
            Write(value.ToString() + NewLine);
        }
        public override void WriteLine(object value)
        {
            if (value == null)
            {
                WriteLine();
            }
            else
            {
                // Call WriteLine(value.ToString), not Write(Object), WriteLine().
                // This makes calls to WriteLine(Object) atomic.
                if (value is IFormattable f)
                {
                    WriteLine(f.ToString(null, FormatProvider));
                }
                else
                {
                    WriteLine(value.ToString());
                }
            }
        }
    }
}
