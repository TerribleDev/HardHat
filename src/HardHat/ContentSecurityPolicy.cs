using System;
using System.Collections.Generic;
using System.Text;

namespace HardHat
{
    public class ContentSecurityPolicy
    {
        /// <summary>
        /// The default-src is the default policy for loading content such as JavaScript, Images, CSS, Font's, AJAX requests, Frames, HTML5 Media.
        /// </summary>
        public HashSet<string> DefaultSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of JavaScript. 
        /// </summary>
        public HashSet<string> ScriptSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of stylesheets. 
        /// </summary>
        public HashSet<string> StyleSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of images. 
        /// </summary>
        public HashSet<string> ImgSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Applies to XMLHttpRequest (AJAX), WebSocket or EventSource. If not allowed the browser emulates a 400 HTTP status code. 
        /// </summary>
        public HashSet<string> ConnectSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of fonts. 
        /// </summary>
        public HashSet<string> FontSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of plugins, eg <object>, <embed> or <applet>. 
        /// </summary>
        public HashSet<string> ObjectSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of audio and video, eg HTML5 <audio>, <video> elements. 
        /// </summary>
        public HashSet<string> MediaSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources for web workers and nested browsing contexts loaded using elements such as <frame> and <iframe> 
        /// </summary>
        public HashSet<string> ChildSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources that can be used as a HTML <form> action.
        /// </summary>
        public HashSet<string> FormAction { get; set; } = new HashSet<string>();

        /// <summary>
        /// Defines valid sources for embedding the resource using <frame> <iframe> <object> <embed> <applet>. Setting this directive to 'none' should be roughly equivalent to X-Frame-Options: DENY 
        /// </summary>
        public HashSet<string> FrameAncestors { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid MIME types for plugins invoked via <object> and <embed>. To load an <applet> you must specify application/x-java-applet. 
        /// </summary>
        public HashSet<string> PluginTypes { get; set; } = new HashSet<string>();

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) sandbox directive enables a sandbox for the requested resource similar to the <iframe> sandbox attribute. It applies restrictions to a page's actions including preventing popups, preventing the execution of plugins and scripts, and enforcing a same-origin policy.
        /// </summary>
        public BaseSandboxOption Sandbox { get; set; } = null;


        public string ReportUri = string.Empty;
        /// <summary>
        /// Reports violations that would have occurred. Does not actively enforce the Content Policy
        /// </summary>
        public bool OnlySendReport { get; set;  } = false;

        public bool UpgradeInsecureResponse { get; set; } = false;

    }
}
