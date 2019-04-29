using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.DependencyServices
{
    public interface IStorageService
    {
        string GetLogFilePath();

    }
}
