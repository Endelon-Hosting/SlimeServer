using System;
using System.IO;

namespace SlimeServer.Extensions
{
    public struct File
    {
        public File(string filename)
        {
            Filename = filename;
            IsOpen = false;
            _open = null;
        }
        
        public string Filename { get; set; }
        private Stream _open;

        public void Open(string filename)
        {
            Filename = filename;
        }

        public bool Exists
        {
            get
            {
                return System.IO.File.Exists(Filename);
            }
        }

        public bool IsOpen
        {
            get;
            private set;
        }

        public string ReadText()
        {
            return System.IO.File.ReadAllText(Filename);
        }

        public string[] ReadLines()
        {
            return System.IO.File.ReadAllLines(Filename);
        }

        public byte[] ReadBytes()
        {
            return System.IO.File.ReadAllBytes(Filename);
        }

        public void WriteText(string text)
        {
             System.IO.File.WriteAllText(Filename, text);
        }

        public void WriteLines(string[] lines)
        {
            System.IO.File.WriteAllLines(Filename, lines);
        }

        public void WriteBytes(byte[] bytes)
        {
            System.IO.File.WriteAllBytes(Filename, bytes);
        }

        public Stream Open()
        {
            if (!IsOpen)
            {
                _open = System.IO.File.Open(Filename, FileMode.Append);
                IsOpen = true;
            }
            return _open;
        }

        public void Close()
        {
            if (IsOpen)
            {
                _open.Close();
                IsOpen = false;
            }
        }

        public static bool operator ==(File a, File b)
        {
            return a.Filename == b.Filename;
        }

        public static bool operator !=(File a, File b)
        {
            return a.Filename != b.Filename;
        }

        public override bool Equals(object obj)
        {
            if(obj is File f)
                return f.Filename == Filename;
            return false;
        }

        public override int GetHashCode()
        {
            return Filename.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name}: \nFilename: {Filename}\nExists: {Exists}\nIsOpen: {IsOpen}";
        }
    }
}