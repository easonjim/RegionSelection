using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using RegionSelection.Model;
using RegionSelection.Service;

namespace RegionSelection
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

    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class DataHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request["id"];
            if (id != "")
            {
                RootObject ro = new RootObject();
                ro.message = new List<Message>();
                RegionService.Instance.Get_Entity_byWhere(Region._.parentId == id, null).ForEach(obj =>
                {

                    ro.message.Add(new Message()
                    {
                        display = obj.display,
                        id = obj.id,
                        type = obj.type.Value,
                        name = obj.name,
                        parentId = obj.parentId.Value,
                        shortName = obj.shortName
                    });
                });
                JavaScriptSerializer js = new JavaScriptSerializer();
                ro.success = true;
                context.Response.Write(js.Serialize(ro));
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}