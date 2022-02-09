using Spectre.Console;
using System;

namespace SlimeServer
{
    public static class Logger
    {
        public static string InfoPrefix
        {
            get
            {
                return "Info";
            }
        }
        public static ConsoleColor InfoColor
        {
            get
            {
                return ConsoleColor.Blue;
            }
        }
        public static string DebugPrefix
        {
            get
            {
                return "Debug";
            }
        }
        public static ConsoleColor DebugColor
        {
            get
            {
                return ConsoleColor.Green;
            }
        }
        public static string WarnPrefix
        {
            get
            {
                return "Warn";
            }
        }
        public static ConsoleColor WarnColor
        {
            get
            {
                return ConsoleColor.Yellow;
            }
        }
        public static string ErrorPrefix
        {
            get
            {
                return "Error";
            }
        }
        public static ConsoleColor ErrorColor
        {
            get
            {
                return ConsoleColor.Red;
            }
        }
        public static LogfileManager Logfile { get; private set; }

        public static void Info(string message)
        {
            ColorOutput(InfoPrefix , message, InfoColor);
        }

        public static void Debug(string message)
        {
            ColorOutput(DebugPrefix , message, DebugColor);
        }

        public static void Warn(string message)
        {
            ColorOutput(WarnPrefix , message, WarnColor);
        }

        public static void Error(string message)
        {
            ColorOutput(ErrorPrefix,message, ErrorColor);
        }

        private static void ColorOutput( string category,string message, ConsoleColor color)
        {
            var str = $"[bold] {DateTime.Now.ToShortTimeString()} [/][{color.ToString().ToLower()}] {category} [/] > [white]{message}[/]";
            AnsiConsole.MarkupLine(str);
            Logfile?.Log(str);
        }

        public static void Info(object message)
        {
            Info(message.ToString());
        }

        public static void Debug(object message)
        {
            Debug(message.ToString());
        }

        public static void Warn(object message)
        {
            Warn(message.ToString());
        }

        public static void Error(object message)
        {
            Error(message.ToString());
        }
    }
}