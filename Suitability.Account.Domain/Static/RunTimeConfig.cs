﻿using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Suitability.Account.Domain.Static
{
    public static class RunTimeConfig
    {
        public static string? Auroraconnection = "";
        public static string? Mongoconnection = "";
        public static string CannabisEndpoint = "";

        public static void SetConfigs(ConfigurationManager configuration)
        {
            if (Debugger.IsAttached)
            {
                Auroraconnection = configuration.GetConnectionString("Auroraconnection");
                Mongoconnection = configuration.GetConnectionString("Mongoconnection");
            }
            else
            {
                Auroraconnection = Environment.GetEnvironmentVariable("Auroraconnection");
                Mongoconnection = Environment.GetEnvironmentVariable("Mongoconnection");
            }
        }

    }
}