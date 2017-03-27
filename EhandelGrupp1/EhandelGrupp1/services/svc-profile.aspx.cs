﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1;

namespace EhandelGrupp1.services
{
    public partial class svc_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var user = DataManagement.GetCustomerByID(int.Parse(Request["id"]));
                LiteralProfile.Text = user;
            }
        }
    }
}