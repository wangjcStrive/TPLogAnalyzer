﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPLogAnalyzer.Config;

/// <summary>
/// knowledge
///     1. Excel read/write with NPOI
///     2. C# string split/
///     3. xml config file
///     4. IOC. inversion of control
///         Autofac
/// </summary>

namespace TPLogAnalyzer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // todo. IOC is init at here?
            IContainer IOC;
            ContainerBuilder builer = new ContainerBuilder();
            builer.RegisterInstance<IAnalyzerConfigReader>(new ConfigRedaer(enumLogType.stsLogType)).Named<IAnalyzerConfigReader>("StsConfig");
            builer.RegisterInstance<IAnalyzerConfigReader>(new ConfigRedaer(enumLogType.DevLogType)).Named<IAnalyzerConfigReader>("DevConfig");
            IOC = builer.Build();
        }
    }
}
