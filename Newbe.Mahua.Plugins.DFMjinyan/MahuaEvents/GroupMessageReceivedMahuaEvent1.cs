using Newbe.Mahua.MahuaEvents;
using System;

namespace Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents
{
    public static class Common
    {
        //存储全局静态变量
        public static string msg = "000";  //消息缓存
        public static string msgQq = "000000000";  //缓存消息的QQ号
        public static System.Collections.Generic.List<string> QQList = new System.Collections.Generic.List<string>();   //禁言管理QQ列表
        public static System.Collections.Generic.List<string> DieList = new System.Collections.Generic.List<string>();   //禁言关键词
        public static int execuateTime = 1;   //禁言时间
        public static int execuateMode = 1;  //禁言模式
    }
    /// <summary>
    /// 群消息接收事件
    /// </summary>
    /// 
    public class GroupMessageReceivedMahuaEvent1
        : IGroupMessageReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public GroupMessageReceivedMahuaEvent1(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {
            var token = context.MessageCancelToken;
            Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.msg = context.Message;
            Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.msgQq = context.FromQq;
            if(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateMode == 1)
            { 
                for (int k = 0; k < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Count; k++)
                {
                    if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.msg.Contains(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList[k]))
                    {
                        for (int l = 0; l < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Count; l++)
                        {
                            if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.msgQq == Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[l])
                            {
                                _mahuaApi.BanGroupMember(context.FromGroup, Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[l], TimeSpan.FromMinutes(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateTime));
                                token.Cancel();
                            }
                        }
                    }
                }
            }

            if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateMode == 2)
            {
                for (int k = 0; k < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Count; k++)
                    if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.msg.Contains(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList[k]))
                    {
                        _mahuaApi.BanGroupMember(context.FromGroup, context.FromQq, TimeSpan.FromMinutes(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateTime));
                        token.Cancel();
                    }
            }

            if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateMode == 3)
            {
                Random r = new Random(2);
                int x=r.Next();
                for (int k = 0; k < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList.Count; k++)
                {
                    if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.msg.Contains(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.DieList[k]))
                    {
                        for (int l = 0; l < Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList.Count; l++)
                        {
                            if (Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.msgQq == Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[l])
                            {
                                if (x == 1)
                                {
                                    _mahuaApi.BanGroupMember(context.FromGroup, Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.QQList[l], TimeSpan.FromMinutes(Newbe.Mahua.Plugins.DFMjinyan.MahuaEvents.Common.execuateTime));
                                    token.Cancel();
                                }
                            }
                        }
                    }
                }
            }
        }
            // todo 填充处理逻辑
           // throw new NotImplementedException();

            // 不要忘记在MahuaModule中注册
        }
    }
}
