using System;
using System.IO;
using MIYO_Weather.Qweather.QweatherIcon.IconFont;
using Newtonsoft.Json;

namespace MIYO_Weather.Qweather.QweatherIcon
{
    public static class QweatherIcon
    {
        public static iconlist? ReadIconMap()
        {
            const string iconmapPath = "MIYO_Weather.Qweather.QweatherIcon.IconFont.icons-list.json";
            using Stream? iconmapStream = MIYO_EmbeddedResource.LoadAssetStream(iconmapPath);
            if (iconmapStream == null) { throw new Exception("内部资源读取失败"); }
            using StreamReader streamReader = new StreamReader(iconmapStream);
            return JsonConvert.DeserializeObject<iconlist>(streamReader.ReadToEnd());
        }

        public static string? ConvertToFontTable(string iconCode)
        {
            var iconmap = ReadIconMap();
            for (var i = 0; i < iconmap.data.Length; i++)
            {
                if (iconCode == iconmap.data[i].icon_code)
                {
                    string? icon = char.ConvertFromUtf32(0xf1 * 256 + (i + 1));
                    return icon;
                }
            }
            return null;
        }
        
        
    }
}