//using System;
//using System.Linq;
//using System.Text;
//using System.Collections.Generic;
//using SIS.MvcFramework;
//using SIS.MvcFramework.ViewEngine;

//namespace MyAppViews
//{
//    public class Channels_FollowedView : IView<System.Collections.Generic.List`1[[MishMash.App.ViewModels.ChannelModel, MishMash.App, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null]]>
//    {
//        public string GetHtml(System.Collections.Generic.List`1[[MishMash.App.ViewModels.ChannelModel, MishMash.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] model, private MvcUserInfo user)

//        {
//            private StringBuilder html = new StringBuilder();

//        private var Model = model;
//        private var User = user;

//        html.AppendLine("<h1 class=\"text-center text-mishmash\">Following</h1>");
//html.AppendLine("<hr class=\"hr-2 bg-mishmash\" />");
//html.AppendLine("<table class=\"table w-75 mx-auto table-hover\">");
//html.AppendLine("    <thead>");
//html.AppendLine("        <tr class=\"row\">");
//html.AppendLine("            <th class=\"col-md-1\">#</th>");
//html.AppendLine("            <th class=\"col-md-5\">Channel</th>");
//html.AppendLine("            <th class=\"col-md-1\">Type</th>");
//html.AppendLine("            <th class=\"col-md-2\">Followers</th>");
//html.AppendLine("            <th class=\"col-md-2\">Actions</th>");
//html.AppendLine("        </tr>");
//html.AppendLine("    </thead>");
//html.AppendLine("    <tbody>");
//        for(var i = 0; i<Model.FollowedChannels.Count(); i++)
//        {
// private var channel = Model.FollowedChannels.ToList()[i];
//        private var index = i + 1;
//        html.AppendLine("        <tr class=\"row\">");
//html.AppendLine("            <th class=\"col-md-1\">" + index + "</th>");
//html.AppendLine("            <td class=\"col-md-5\">" + channel.Name + "</td>");
//html.AppendLine("            <td class=\"col-md-1\">" + channel.Type + "</td>");
//html.AppendLine("            <td class=\"col-md-2\">" + channel.FollowersCount + "</td>");
//html.AppendLine("            <td class=\"col-md-2\">");
//html.AppendLine("                <div class=\"button-holder d-flex justify-content-between\">");
//html.AppendLine("                    <a href=\"/Channels/Unfollow?id=" + channel.Id + "\" class=\"btn bg-mishmash text-white\">Unfollow</a>");
//html.AppendLine("                    <a href=\"/Channels/Details?id=" + channel.Id + "\" class=\"btn bg-mishmash text-white\">Details</a>");
//html.AppendLine("                </div>");
//html.AppendLine("            </td>");
//html.AppendLine("        </tr>");
//        }

//    html.AppendLine("    </tbody>");
//html.AppendLine("</table>");

//            return html.ToString().TrimEnd();
//}