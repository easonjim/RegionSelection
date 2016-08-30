using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySoft.Data;
using MySoft.Data.Ext;
using Example.Model;
using Example.Service;

namespace data
{
    public class Message
    {
        public string display { get; set; }
        public Int64 id { get; set; }
        public string name { get; set; }
        public Int64 parentId { get; set; }
        public string shortName { get; set; }
        public int type { get; set; }
    }

    public class RootObject
    {
        public List<Message> message { get; set; }
        public bool success { get; set; }
    }

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //采集数据

            /*List<Message> message = new List<Message>();
            GetListData(message, 1);
            message.ForEach(obj =>
                {
                    dataService.Instance.Add_Entity(new Example.Model.data()
                        {
                            display = obj.display,
                            id = obj.id,
                            name = obj.name,
                            parentId = obj.parentId,
                            shortName = obj.shortName,
                            type = obj.type

                        });

                });*/


        }

        private void GetListData(List<Message> message, Int64 id)
        {
            var data = SerializerData(id);
            if (data!=null)
            {
                var list = data.message;
                list.ForEach(obj =>
                    {
                        message.Add(obj);
                        if (obj.type<4)
                        {
                            GetListData(message, obj.id);
                        }

                    });
                }
            

        }

        private RootObject SerializerData(Int64 id)
        {
            RootObject ro = new RootObject();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var strdata = GetData(id);
            if (strdata.Contains("服务器繁忙")) return null;
            ro = js.Deserialize<RootObject>(strdata);
            return ro;
        }

        private string GetData(Int64 id)
        {
            //初始化WebClient
            WebClient webClient = new WebClient();

            webClient.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            //webClient.Headers.Add("Connection", "keep-alive");
            webClient.Headers.Add("X-Requested-With", "XMLHttpRequest");
            //webClient.Headers.Add("Accept-Encoding", "gzip, deflate");
            webClient.Headers.Add("Accept-Language", "zh-cn");
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            webClient.Headers.Add("Origin", "http://www.56laile.com");
            //webClient.Headers.Add("Connection", "keep-alive");
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 9_0_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13A404 MicroMessenger/6.3.6 NetType/WIFI Language/zh_CN");

            string postData = "id="+id;
            //将字符串转换成字节数组
            byte[] postBy = Encoding.Default.GetBytes(postData);

            //上传数据，返回页面的字节数组
            //byte[] buff = webclient.DownloadData(url);
            //string cookie = webclient.ResponseHeaders.Get("Set-Cookie");
            byte[] responseData = webClient.UploadData("http://www.56laile.com/addressItem.html", "POST", postBy);

            // 将返回的将字节数组转换成字符串(HTML);
            // ASP.NET 返回的页面一般是Unicode,如果是简体中文应使用 
            // Encoding.GetEncoding("GB2312").GetString(responseData)
            string srcString = Encoding.UTF8.GetString(responseData).Replace("\"[","[").Replace("]\"","]").Replace("\\\"","\"");

            return srcString;
        }
    }
}