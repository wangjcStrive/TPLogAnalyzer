namespace TPLogAnalyzer.Config
{
    class ConfigModel
    {
        private string m_keyWord;
        private bool m_fontBold;
        private string m_fontColor;
        private uint m_fontSize;
        private string m_backgroundColor;

        public ConfigModel(string keyword, string fontBold, string fontColor, string fontSize, string backgroundColor)
        {
            m_keyWord = keyword;
            m_fontBold = fontBold.ToLower() == "true" ? true : false;
            m_fontColor = fontColor;
            if (!uint.TryParse(fontSize, out m_fontSize))
                m_fontSize = 11;
            m_backgroundColor = backgroundColor;
        }

        public string KeyWord { get => m_keyWord; set => m_keyWord = value; }
        public bool FontBold { get => m_fontBold; set => m_fontBold = value; }
        public string FontColor { get => m_fontColor; set => m_fontColor = value; }
        public string BackgroundColor { get => m_backgroundColor; set => m_backgroundColor = value; }
        public uint FontSize { get => m_fontSize; set => m_fontSize = value; }
    }
}
