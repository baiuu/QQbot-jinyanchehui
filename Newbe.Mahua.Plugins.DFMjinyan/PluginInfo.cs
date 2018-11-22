﻿namespace Newbe.Mahua.Plugins.DFMjinyan
{
    /// <summary>
    /// 本插件的基本信息
    /// </summary>
    public class PluginInfo : IPluginInfo
    {
        /// <summary>
        /// 版本号，建议采用 主版本.次版本.修订号 的形式
        /// </summary>
        public string Version { get; set; } = "1.0.0";

        /// <summary>
        /// 插件名称
        /// </summary>

        public string Name { get; set; } = "指定群友关键字禁言";

        /// <summary>
        /// 作者名称
        /// </summary>
        public string Author { get; set; } = "Miemie";

        /// <summary>
        /// 插件Id，用于唯一标识插件产品的Id，至少包含 AAA.BBB.CCC 三个部分
        /// </summary>
        public string Id { get; set; } = "Newbe.Mahua.Plugins.DFMjinyan";

        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description { get; set; } = "禁言一部分干话群友";
    }
}
