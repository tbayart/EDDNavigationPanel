using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EDDNavigationPanel
{
    public static class Toolbox
    {
        public static void Log(string message,
            [CallerMemberName] string caller = null)
        {
            LogInternal(caller, message);
        }

        public static void Log(this Exception ex,
            [CallerMemberName] string caller = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            var source = $"EXCEPTION in {caller} line {lineNumber}";
            LogInternal(source, ex.ToString());
        }

        private static void LogInternal(string source, string message)
        {
            message = string.Join(" ", "EDDNavPanel", source, message);
            System.Diagnostics.Trace.WriteLine(message);
        }
    }
}
