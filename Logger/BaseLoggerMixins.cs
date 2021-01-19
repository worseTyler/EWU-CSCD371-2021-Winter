namespace Logger
{
    using System;

    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params int[] extraParams)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException($"{nameof(baseLogger)} is null");
            }

            string additionalParams = string.Empty;
            foreach (int param in extraParams)
            {
                additionalParams = string.Concat(additionalParams, param.ToString());
            }

            baseLogger.Log(LogLevel.Error, string.Format(message, additionalParams));
        }

        public static void Debug(this BaseLogger baseLogger, string message, params int[] extraParams)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException($"{nameof(baseLogger)} is null");
            }

            string additionalParams = string.Empty;
            foreach (int param in extraParams)
            {
                additionalParams = string.Concat(additionalParams, param.ToString());
            }

            baseLogger.Log(LogLevel.Debug, string.Format(message, additionalParams));
        }

        public static void Information(this BaseLogger baseLogger, string message, params int[] extraParams)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException($"{nameof(baseLogger)} is null");
            }

            string additionalParams = string.Empty;
            foreach (int param in extraParams)
            {
                additionalParams = string.Concat(additionalParams, param.ToString());
            }

            baseLogger.Log(LogLevel.Information, string.Format(message, additionalParams));
        }

        public static void Warning(this BaseLogger baseLogger, string message, params int[] extraParams)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException($"{nameof(baseLogger)} is null");
            }

            string additionalParams = string.Empty;
            foreach (int param in extraParams)
            {
                additionalParams = string.Concat(additionalParams, param.ToString());
            }

            baseLogger.Log(LogLevel.Warning, string.Format(message, additionalParams));
        }
    }
}
