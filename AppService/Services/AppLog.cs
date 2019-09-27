using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Services
{
    public static class AppLog
    {
        public static Logger Instance { get; private set; }

        static AppLog()
        {
            LogManager.ReconfigExistingLoggers();
            Instance = LogManager.GetCurrentClassLogger();
        }

        public static void LogDatabaseException(System.Data.Entity.Validation.DbEntityValidationException dbEx)
        {
            Exception raise = dbEx;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    string message = string.Format("{0}:{1}",
                        validationErrors.Entry.Entity.ToString(),
                        validationError.ErrorMessage);
                    raise = new InvalidOperationException(message, raise);
                    Instance.Fatal(raise);
                }
            }
        }

    }
}