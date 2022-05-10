using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonClass
{
    //如果好用，请收藏地址，帮忙分享。
    public class DaysItem
    {
        /// <summary>
        /// 天数
        /// </summary>
        public float count { get; set; }
    }

    public class ContributionsItem
    {
        /// <summary>
        /// 周数
        /// </summary>
        public float week { get; set; }

        /// <summary>
        /// 天数列表
        /// </summary>
        public List<DaysItem> days { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// Github名称
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 所选择年份
        /// </summary>
        public string year { get; set; }

        /// <summary>
        /// 最小贡献
        /// </summary>
        public float min { get; set; }

        /// <summary>
        /// 最大贡献
        /// </summary>
        public float max { get; set; }

        /// <summary>
        /// 贡献中位数
        /// </summary>
        public float median { get; set; }

        /// <summary>
        /// 贡献前80%数量
        /// </summary>
        public float p80 { get; set; }

        /// <summary>
        /// 贡献前90%数量
        /// </summary>
        public float p90 { get; set; }

        /// <summary>
        /// 贡献前99%数量
        /// </summary>
        public float p99 { get; set; }

        /// <summary>
        /// 具体贡献数据
        /// </summary>
        public List<ContributionsItem> contributions { get; set; }
    }
}