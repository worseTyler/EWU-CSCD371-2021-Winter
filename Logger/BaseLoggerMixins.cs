namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params int[] extraParams)
        {
            if(baseLogger == null)
                throw new System.ArgumentNullException(); //TODO: When I added message the test didn't pass
            string additionalParams = "";
            foreach (int param in extraParams)
            {
                additionalParams = System.String.Concat(additionalParams, param.ToString());
            }
            baseLogger.Log(LogLevel.Error, string.Format(message, extraParams[0]));
        }
    }
}
