using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLogAnalyzer.Config
{
    class ConfigModel
    {
        private string m_keyWord;
        private string m_fontBold;
        private string m_fontColor;
        private string m_backgroundColor;

        public string KeyWord { get => m_keyWord; set => m_keyWord = value; }
        public string FontBold { get => m_fontBold; set => m_fontBold = value; }
        public string FontColor { get => m_fontColor; set => m_fontColor = value; }
        public string BackgroundColor { get => m_backgroundColor; set => m_backgroundColor = value; }
    }
}
