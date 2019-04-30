using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LogApp.Services
{
    public class LoggerService : ILoggerService
    {
        private ILoggerFacade _LoggerFacade;
        public LoggerService(ILoggerFacade loggerFacade)
        {
            _LoggerFacade = loggerFacade;
        }

        public void Log(string message, Category category = Category.Debug, Priority priority = Priority.None,
                                [CallerMemberName] string memberName = "",
                              [CallerFilePath] string filePath = "",
                              [CallerLineNumber] int lineNumber = -1)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            //_LoggerFacade.Log($"{message}：{memberName}, {fileName}, {lineNumber}", category, priority);
            _LoggerFacade.Log($"{message}：{fileName} {lineNumber}", category, priority);
        }

    }
}
