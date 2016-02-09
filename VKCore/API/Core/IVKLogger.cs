using System;

namespace VKCore.API.Core
{
    public interface IVKLogger
    {
        void Info(string info, params object[] formatParameters);
        void Warning(string warning);
        void Error(string error, Exception exc = null);
    }

}
