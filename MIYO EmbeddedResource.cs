using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace MIYO_Weather
{
    public class MIYO_EmbeddedResource
    {
        /// <summary>
        /// 加载嵌入式资源流
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Stream? LoadAssetStream(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(path);
        }

        /// <summary>
        /// 解析流到String
        /// </summary>
        /// <param name="AssetStream"></param>
        /// <returns></returns>
        public static string? ParseAssetStreamToString(Stream? AssetStream) 
        {
            if (AssetStream != null)
            {
                try 
                {
                    using (var Reader = new StreamReader(AssetStream))
                    {
                        return Reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Message:" + ex.Message + "  Source:" + ex.Source, "Error");
                    return null;
                }
            }
            return null;
        }
    }
}