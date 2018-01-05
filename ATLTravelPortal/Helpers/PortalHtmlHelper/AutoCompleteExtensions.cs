using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ATLTravelPortal.Helpers.PortalHtmlHelper
{
    /// AutoComplete Extensions
    /// </summary>
    public static class AutoCompleteExtensions
    {
        /// <summary>
        /// Create an autocomplete component, based on the jquery ui
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="helper">Helper Html with Model</param>
        /// <param name="exprValueField">Value field - this field will be used to assign a value in the hidden field</param>
        /// <param name="exprDisplayField">Display field - this will be displayed in the field list</param>
        /// <param name="action">Action that returns a list of values</param>
        /// <returns></returns>
        public static MvcHtmlString AutoCompleteFor<T, Tvalue, Tdisplay>(this HtmlHelper<T> helper,
                                                            Expression<Func<T, Tvalue>> exprValueField,
                                                            Expression<Func<T, Tdisplay>> exprDisplayField,
                                                            string action)
        {

            return BuildComponent(helper, exprValueField, exprDisplayField, action, typeof(T).Name, 1);
        }

        /// <summary>
        /// Create an autocomplete component, based on the jquery ui
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="helper">Helper Html with Model</param>
        /// <param name="exprValueField">Value field - this field will be used to assign a value in the hidden field</param>
        /// <param name="exprDisplayField">Display field - this will be displayed in the field list</param>
        /// <param name="action">Action that returns a list of values</param>
        /// <param name="minimumLength">Minimum amount of characters to search</param>
        /// <returns></returns>
        public static MvcHtmlString AutoCompleteFor<T, Tvalue, Tdisplay>(this HtmlHelper<T> helper,
                                                            Expression<Func<T, Tvalue>> exprValueField,
                                                            Expression<Func<T, Tdisplay>> exprDisplayField,
                                                            string action,
                                                            int minimumLength)
        {

            return BuildComponent(helper, exprValueField, exprDisplayField, action, typeof(T).Name, minimumLength);
        }

        private static string HeaderJscript(/*string tName,*/ string displayField, string controller, string action, string valueField)
        {
            StringBuilder strJscript = new StringBuilder();
            strJscript.Append("<script type=\"text/javascript\">");
            //strJscript.AppendFormat("$('#{0}{1}').autocomplete({2}", tName, displayField, "{");
            strJscript.AppendFormat("$('#{0}').autocomplete({1}",displayField, "{");
            strJscript.AppendFormat("source:function(request,response) {0}", "{");
            strJscript.Append("$.ajax({");
            strJscript.AppendFormat("url:'../{0}/{1}'", controller, action);
            strJscript.Append(",dataType:'json'");
            strJscript.AppendFormat(",data:{0}{1}:request.term{2}", "{", displayField, "}");
            strJscript.Append(",success:function(data){");
            //strJscript.AppendFormat(" if(data.length==0) {2}data.push({2}{0}:null,{1}:'Not Found.'{3});$('#{4}{5}').val(null);{3};", valueField, displayField, "{", "}", tName, valueField);
             strJscript.AppendFormat(" if(data.length==0) {2}data.push({2}{0}:null,{1}:'Not Found.'{3});$('#{4}').val(null);{3};", valueField, displayField, "{", "}",valueField);
            strJscript.Append("response ($.map(data,function(item){");
            strJscript.Append(" return {");

            return strJscript.ToString();
        }

        private static string BodyJscript(/*string tName,*/ string displayField, string valueField, int minimumLength)
        {
            StringBuilder strJscript = new StringBuilder();

            strJscript.AppendFormat("label:item.{0} ", displayField);
            strJscript.AppendFormat(",value:item.{0}", displayField);
            strJscript.AppendFormat(",id:item.{0}", valueField);
            strJscript.Append("};}));}});}");
            strJscript.AppendFormat(",minLength: {0}", minimumLength);
            strJscript.AppendFormat(",select: function(event, ui) {0}", "{");
            strJscript.Append("if(ui.item.id==null) return false;");
            //strJscript.AppendFormat("$('#{0}{1}').val( ui.item.id);", tName, valueField);
            strJscript.AppendFormat("$('#{0}').val( ui.item.id);", valueField);
            strJscript.Append("}});");
            strJscript.Append("</script>");

            return strJscript.ToString();
        }

        private static string BodyJscript(/*string tName,*/ IDictionary<string, string> displayFields, string valueField, int minimumLength)
        {
            StringBuilder strJscript = new StringBuilder();
            StringBuilder displayValues = new StringBuilder();

            int i = 0;
            foreach (var displayField in displayFields)
            {
                if (i == 0)
                    displayValues.AppendFormat("item.{1} + \" - \" + ", displayField.Key, displayField.Value);
                else if (i + 1 == displayFields.Count)
                    displayValues.AppendFormat("\"{0}:\" + item.{1}", displayField.Key, displayField.Value);
                else
                    displayValues.AppendFormat("\"{0}:\" + item.{1} + \" - \" + ", displayField.Key, displayField.Value);
                i++;
            }


            strJscript.AppendFormat("label:function(){1} if(item.{3}=='Not Found.') {1}return 'Not Found';{2} else {1} return {0}{2}{2}", displayValues.ToString(), "{", "}", displayFields.FirstOrDefault().Key);
            strJscript.AppendFormat(",value:item.{0}", displayFields.FirstOrDefault().Value);
            strJscript.AppendFormat(",id:item.{0}", valueField);
            strJscript.Append("};}));}});}");
            strJscript.AppendFormat(",minLength: {0}", minimumLength);
            strJscript.AppendFormat(",width: 150");
            strJscript.AppendFormat(",selectFirst: true");
            strJscript.AppendFormat(",select: function(event, ui) {0}", "{");
            //strJscript.Append("if(ui.item.id==null) return false;");
            //strJscript.AppendFormat("$('#{0}{1}').val( ui.item.id);", tName, valueField);
            strJscript.AppendFormat("$('#{0}').val( ui.item.id);", valueField);
            strJscript.Append("}});");
            strJscript.Append("</script>");

            return strJscript.ToString();
        }

        private static MvcHtmlString BuildComponent<T, Tvalue, Tdisplay>(this HtmlHelper<T> helper,
                                                            Expression<Func<T, Tvalue>> exprValueField,
                                                            Expression<Func<T, Tdisplay>> exprDisplayField,
                                                            string action,
                                                            string controller,
                                                            int minimumLength)
        {



            var valueField = ExpressionHelper.GetExpressionText(exprValueField);
            var displayField = ExpressionHelper.GetExpressionText(exprDisplayField);
            string stringText = null;
            IDictionary<string, string> displayValues = new Dictionary<string, string>();

            if (valueField == "")
                throw new InvalidCastException("Invalid expression for value field. AutoCompleteFor Extensions not supported anonymous type in value field.");


            if (displayField == "")
            {
                var fields = exprDisplayField.ToString().Split('(')[1].Split(',');

                foreach (var field in fields)
                {
                    var label = field.Split('=')[0].Replace(" ", "");
                    var val = field.Split('=')[1].Replace(" ", "").Replace(")", "");
                    displayValues.Add(label.Replace("_", " "), val.Substring(val.IndexOf(".") + 1, val.Length - (val.IndexOf(".") + 1)));
                }
                displayField = displayValues.FirstOrDefault().Key;
                stringText = helper.Editor(displayValues.FirstOrDefault().Key).ToHtmlString();
            }
            else
                stringText = helper.EditorFor(exprDisplayField).ToHtmlString();

            var stringHidden = helper.HiddenFor(exprValueField).ToString();

            var tName = typeof(T).Name;

            //stringHidden = stringHidden.Replace(valueField, string.Concat(tName, valueField));
            //stringText = stringText.Replace(displayField, string.Concat(tName, displayField));
            stringHidden = stringHidden.Replace(valueField,  valueField);
            stringText = stringText.Replace(displayField, displayField);

            StringBuilder strJscript = new StringBuilder();

            //strJscript.Append(HeaderJscript(tName, displayField, controller, action, valueField).ToString());
            strJscript.Append(HeaderJscript(displayField, controller, action, valueField).ToString());

            if (displayValues.Count > 0)
                //strJscript.Append(BodyJscript(tName, displayValues, valueField, minimumLength).ToString());
                strJscript.Append(BodyJscript(displayValues, valueField, minimumLength).ToString());
            else
                //strJscript.Append(BodyJscript(tName, displayField, valueField, minimumLength)).ToString();
                strJscript.Append(BodyJscript(displayField, valueField, minimumLength)).ToString();

            string dd = (String.Concat(stringText, stringHidden, strJscript.ToString()));
            return MvcHtmlString.Create(dd);

        }


        /// <summary>
        /// Create an autocomplete component, based on the jquery ui
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="helper">Helper Html with Model</param>
        /// <param name="exprValueField">Value field - this field will be used to assign a value in the hidden field</param>
        /// <param name="exprDisplayField">Display field - this will be displayed in the field list</param>
        /// <param name="action">Action that returns a list of values</param>
        /// <param name="controller">Controller for the action</param>
        /// <returns></returns>
        public static MvcHtmlString AutoCompleteFor<T, Tvalue, Tdisplay>(this HtmlHelper<T> helper,
                                                            Expression<Func<T, Tvalue>> exprValueField,
                                                            Expression<Func<T, Tdisplay>> exprDisplayField,
                                                            string action,
                                                            string controller)
        {
            return BuildComponent(helper, exprValueField, exprDisplayField, action, controller, 1);
        }

        /// <summary>
        /// Create an autocomplete component, based on the jquery ui
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="helper">Helper Html with Model</param>
        /// <param name="exprValueField">Value field - this field will be used to assign a value in the hidden field</param>
        /// <param name="exprDisplayField">Display field - this will be displayed in the field list</param>
        /// <param name="action">Action that returns a list of values</param>
        /// <param name="controller">Controller for the action</param>
        /// <param name="minimumLength">Minimum amount of characters to search</param>
        /// <returns></returns>
        public static MvcHtmlString AutoCompleteFor<T, Tvalue, Tdisplay>(this HtmlHelper<T> helper,
                                                            Expression<Func<T, Tvalue>> exprValueField,
                                                            Expression<Func<T, Tdisplay>> exprDisplayField,
                                                            string action,
                                                            string controller,
                                                            int minimumLength)
        {
            return BuildComponent(helper, exprValueField, exprDisplayField, action, controller, minimumLength);
        }
    }

}

//<input class="text-box single-line" id="AgencyModelcode" name="AgencyModelcode" type="text" value="" />
//<input id="AgencyModelAgentSearch" name="AgencyModelAgentSearch" type="hidden" value="" />
//Html.AutoCompleteFor(model => model.Id, x => new { code = x.Code, Last_Value = x.LastValue, Id_Stock = x.Id }, "List", "Stock")
//Html.AutoCompleteFor(model => model.Id, x => x.Code, "List", "Stock")
