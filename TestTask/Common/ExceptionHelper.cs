using System;

namespace TestTask.Common
{
    internal static class ExceptionHelper
    {
        internal static string RootMessage(Exception ex)
        {
            var root = ex;
            while (root.InnerException != null) root = root.InnerException;
            return root == ex ? ex.Message : $"{ex.Message}\n→ {root.Message}";
        }
    }
}
