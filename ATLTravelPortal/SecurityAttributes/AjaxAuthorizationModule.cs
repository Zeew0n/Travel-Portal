#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AgentManagementController.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion


using System;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.SecurityAttributes
{
    public class AjaxAuthorizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += CheckForAuthFailure;
        }

        private void CheckForAuthFailure(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            var response = new HttpResponseWrapper(app.Response);
            var request = new HttpRequestWrapper(app.Request);
            var context = new HttpContextWrapper(app.Context);

            CheckForAuthFailure(request, response, context);
        }

        internal void CheckForAuthFailure(HttpRequestBase request, HttpResponseBase response, HttpContextBase context)
        {
            if (true.Equals(context.Items["RequestWasNotAuthorized"]) && request.IsAjaxRequest())
            {
                response.StatusCode = 401;
                response.ClearContent();
            }
        }

        public void Dispose()
        {
        }
    }
}