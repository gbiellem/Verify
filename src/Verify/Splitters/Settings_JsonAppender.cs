﻿using System.Collections.Concurrent;
using System.Collections.Generic;

namespace VerifyTests
{
    public static partial class VerifierSettings
    {
        static ConcurrentBag<JsonAppender> jsonAppenders = new ConcurrentBag<JsonAppender>();

        internal static List<ToAppend> GetJsonAppenders(VerifySettings settings)
        {
            var list = new List<ToAppend>();
            foreach (var appender in jsonAppenders)
            {
                var data = appender(settings);
                if (data != null)
                {
                    list.Add(data.Value);
                }
            }

            return list;
        }

        public static void RegisterJsonAppender(JsonAppender appender)
        {
            Guard.AgainstNull(appender, nameof(appender));
            jsonAppenders.Add(appender);
        }
    }
}