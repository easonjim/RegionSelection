using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Example.Service;

namespace data
{
    public partial class getdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request["id"];
            if (id != "")
            {
                RootObject ro = new RootObject();
                ro.message = new List<Message>();
                dataService.Instance.Get_Entity_byWhere(Example.Model.data._.parentId == id, null).ForEach(obj =>
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
                Response.Write(js.Serialize(ro));
                Response.End();
            }
        }
    }
}