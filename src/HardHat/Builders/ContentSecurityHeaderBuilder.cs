using System;
using System.Collections.Generic;
using System.Text;

namespace HardHat.Builders
{
    internal class ContentSecurityHeaderBuilder
    {
        public static string Build(ContentSecurityPolicy policy)
        {
            var stringBuilder = new StringBuilder();
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }
            if (policy.DefaultSrc != null && policy.DefaultSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.DefaultSrc);
                stringBuilder.Append($" {string.Join(" ", policy.DefaultSrc)}; ");
            }
            if (policy.ScriptSrc != null && policy.ScriptSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.ScriptSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ScriptSrc)}; ");
            }
            if (policy.StyleSrc != null && policy.StyleSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.StyleSrc);
                stringBuilder.Append($" {string.Join(" ", policy.StyleSrc)}; ");
            }
            if (policy.ImgSrc != null && policy.ImgSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.ImgSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ImgSrc)}; ");
            }
            if (policy.ConnectSrc != null && policy.ConnectSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.ConnectSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ConnectSrc)}; ");
            }
            if (policy.FontSrc != null && policy.FontSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.FontSrc);
                stringBuilder.Append($" {string.Join(" ", policy.FontSrc)}; ");
            }
            if (policy.ObjectSrc != null && policy.ObjectSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.ObjectSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ObjectSrc)}; ");
            }
            if (policy.MediaSrc != null && policy.MediaSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.MediaSrc);
                stringBuilder.Append($" {string.Join(" ", policy.MediaSrc)}; ");
            }
            if (policy.ChildSrc != null && policy.ChildSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.ChildSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ChildSrc)}; ");
            }
            if (policy.FormAction != null && policy.FormAction.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.FormAction);
                stringBuilder.Append($" {string.Join(" ", policy.FormAction)}; ");
            }
            if (policy.FrameAncestors != null && policy.FrameAncestors.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.FrameAncestors);
                stringBuilder.Append($" {string.Join(" ", policy.FrameAncestors)}; ");
            }
            if (policy.Sandbox != null)
            {
                stringBuilder.Append(Constants.CSPDirectives.Sandbox);
                stringBuilder.Append($" {policy.Sandbox.Value}; ");
            }
            if (!string.IsNullOrWhiteSpace(policy.ReportUri))
            {
                
                if (policy.OnlySendReport)
                {
                    stringBuilder.Append(Constants.CSPDirectives.ReportUriReportOnly);
                }
                else
                {
                    stringBuilder.Append(Constants.CSPDirectives.ReportUri);
                }
                stringBuilder.Append($" {policy.ReportUri}; ");
            }
            if(policy.PluginTypes != null && policy.PluginTypes.Count > 0)
            {
                stringBuilder.Append(Constants.CSPDirectives.PluginTypes);
                stringBuilder.Append($" {string.Join(" ", policy.PluginTypes)}; ");
            }
            if(policy.UpgradeInsecureRequests)
            {
                stringBuilder.Append($"{Constants.CSPDirectives.UpgradeInsecureRequests}; ");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
