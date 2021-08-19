using Autofac;

namespace TPLogAnalyzer.Config
{
    class IOC
    {
        #region Members
        private static IContainer m_container = null;

        public static IContainer Container { get => m_container; set => m_container = value; }
        #endregion

        public static void iocInit()
        {

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterInstance<IAnalyzerConfigReader>(new ConfigRedaer(enumLogType.stsLogType)).Named<IAnalyzerConfigReader>("StsConfig").SingleInstance();
            builder.RegisterInstance<IAnalyzerConfigReader>(new ConfigRedaer(enumLogType.DevLogType)).Named<IAnalyzerConfigReader>("DevConfig").SingleInstance();
            m_container = builder.Build();
        }
    }
}
