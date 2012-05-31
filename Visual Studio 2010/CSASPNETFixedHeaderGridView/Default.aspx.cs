﻿/********************************** 模块头 **********************************\
* 模块名:     Default.aspx.cs
* 项目名:     CSASPNETFixedHeaderGridView
* 版权(c) Microsoft Corporation
*
* 此.cs文件只用以绑定数据表到GridView。 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CSASPNETFixedHeaderGridView
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 定义一个数据表作为GridView的数据源。
            DataTable tab = new DataTable();
            tab.Columns.Add("a", Type.GetType("System.String"));
            tab.Columns.Add("b", Type.GetType("System.String"));
            tab.Columns.Add("c", Type.GetType("System.String"));
            tab.Columns.Add("d", Type.GetType("System.String"));
            tab.Columns.Add("e", Type.GetType("System.String"));
            tab.Columns.Add("f", Type.GetType("System.String"));
            tab.Columns.Add("g", Type.GetType("System.String"));
            tab.Columns.Add("h", Type.GetType("System.String"));
            tab.Columns.Add("i", Type.GetType("System.String"));
            tab.Columns.Add("j", Type.GetType("System.String"));
            for (int i = 0; i < 35; i++)
            {
                DataRow dr = tab.NewRow();
                dr["a"] = string.Format("row:{0} columns:a", i.ToString().PadLeft(2,'0'));
                dr["b"] = string.Format("row:{0} columns:b", i.ToString().PadLeft(2, '0'));
                dr["c"] = string.Format("row:{0} columns:c", i.ToString().PadLeft(2, '0'));
                dr["d"] = string.Format("row:{0} columns:d", i.ToString().PadLeft(2, '0'));
                dr["e"] = string.Format("row:{0} columns:e", i.ToString().PadLeft(2, '0'));
                dr["f"] = string.Format("row:{0} columns:f", i.ToString().PadLeft(2, '0'));
                dr["g"] = string.Format("row:{0} columns:g", i.ToString().PadLeft(2, '0'));
                dr["h"] = string.Format("row:{0} columns:h", i.ToString().PadLeft(2, '0'));
                dr["i"] = string.Format("row:{0} columns:i", i.ToString().PadLeft(2, '0'));
                dr["j"] = string.Format("row:{0} columns:j", i.ToString().PadLeft(2, '0'));
                tab.Rows.Add(dr);
            }

            // 数据绑定方法。
            gvwList.DataSource = tab;
            gvwList.DataBind();
        }
    }
}