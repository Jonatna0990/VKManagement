﻿using System.Collections.Generic;
using System.Diagnostics;

namespace VKCore.Util
{
    /// <summary>
    /// Holds parameters for data exchange between pages
    /// </summary>
    class VKParametersRepository
    {
        private static Dictionary<string, object> _parametersDict = new Dictionary<string, object>();

        public static void SetParameterForId(string paramId, object parameter)
        {
            Debug.Assert(!string.IsNullOrEmpty(paramId));

            _parametersDict[paramId] = parameter;
        }

        public static object GetParameterForIdAndReset(string paramId)
        {
            if (_parametersDict.ContainsKey(paramId))
            {
                var result = _parametersDict[paramId];

                _parametersDict.Remove(paramId);

                return result;
            }

            return null;
        }

        public static bool Contains(string key)
        {
            return _parametersDict.ContainsKey(key);
        }
    }
}
