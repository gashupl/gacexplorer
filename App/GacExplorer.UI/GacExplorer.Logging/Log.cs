﻿using System;
using NLog;

namespace GacExplorer.Logging
{
    public class Log : ILog
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Trace(string message)
        {
            Logger.Trace(message);
        }

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Warning(string message)
        {
            Logger.Warn(message);
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Fatal(string message)
        {
            Logger.Fatal(message);
        }
    }
}