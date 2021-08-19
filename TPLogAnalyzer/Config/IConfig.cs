using System.Collections.Generic;

namespace TPLogAnalyzer.Config
{
    /// <summary>
    /// 因为要使用autofac，需要一个接口，读配置文件是在构造函数里面，所以这个接口里的readConfig函数是没用的
    /// 本来是想通过该接口继承出3个子类，sts/dev/debug，但是目前3个的config都是一样的，所以只继承出1个ConfigReader子类
    /// </summary>
    interface IAnalyzerConfigReader
    {
        void readConfig(enumLogType logType);

        List<ConfigModel> ConfigList { get; set; }
    }
}
