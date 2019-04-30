using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LogApp.Services
{
    public interface ILoggerService
    {
        void Log(string message, Category category = Category.Debug, Priority priority = Priority.None,
                    [CallerMemberName] string memberName = "",
                    [CallerFilePath] string filePath = "",
                    [CallerLineNumber] int lineNumber = -1);
    }
}
