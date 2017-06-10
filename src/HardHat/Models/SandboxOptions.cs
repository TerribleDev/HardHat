using System;
using System.Collections.Generic;
using System.Text;

namespace HardHat
{
    public abstract class BaseSandboxOption
    {
        internal BaseSandboxOption() { }
        public abstract string Value { get; }
    }

    public class AllowForms : BaseSandboxOption
    {
        internal AllowForms() { }
        public override string Value => "allow-forms";
    }

    public class AllowModals : BaseSandboxOption
    {
        internal AllowModals() { }
        public override string Value => "allow-modals";
    }

    public class AllowOrientationLock : BaseSandboxOption
    {
        internal AllowOrientationLock() { }
        public override string Value => "allow-orientation-lock";
    }

    public class AllowPointerLock : BaseSandboxOption
    {
        internal AllowPointerLock() { }
        public override string Value => "allow-pointer-lock";
    }

    public class AllowPopups : BaseSandboxOption
    {
        internal AllowPopups() { }
        public override string Value => "allow-popups";
    }
    public class AllowPopupsToEscapeSandbox : BaseSandboxOption
    {
        internal AllowPopupsToEscapeSandbox() { }
        public override string Value => "allow-popups-to-escape-sandbox";
    }

    public class AllowPresentation : BaseSandboxOption
    {
        internal AllowPresentation() { }
        public override string Value => "allow-presentation";
    }

    public class AllowSameOrigin : BaseSandboxOption
    {
        internal AllowSameOrigin() { }
        public override string Value => "allow-same-origin";
    }

    public class AllowScripts : BaseSandboxOption
    {
        internal AllowScripts() { }
        public override string Value => "allow-scripts";
    }

    public class AllowTopNaviation : BaseSandboxOption
    {
        internal AllowTopNaviation() { }
        public override string Value => "allow-top-navigation";
    }

    public static class SandboxOption
    {
        /// <summary>
        /// Allows the embedded browsing context to submit forms. If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static AllowForms AllowForms = new AllowForms();
        /// <summary>
        /// Allows the embedded browsing context to open modal windows.
        /// </summary>
        public static AllowModals AllowModals = new AllowModals();
        /// <summary>
        /// Allows the embedded browsing context to disable the ability to lock the screen orientation.
        /// </summary>
        public static AllowOrientationLock AllowOrientationLock = new AllowOrientationLock();
        /// <summary>
        /// Allows the embedded browsing context to use the <a href="https://developer.mozilla.org/en-US/docs/Web/API/Pointer_Lock_API">Pointer Lock API</a>
        /// </summary>
        public static AllowPointerLock AllowPointerLock = new AllowPointerLock();

        /// <summary>
        /// Allows popups (like from window.open, target="_blank", showModalDialog). If this keyword is not used, that functionality will silently fail.
        /// </summary>
        public static AllowPopups AllowPopups = new AllowPopups();
        /// <summary>
        /// Allows a sandboxed document to open new windows without forcing the sandboxing flags upon them. This will allow, for example, a third-party advertisement to be safely sandboxed without forcing the same restrictions upon a landing page.
        /// </summary>
        public static AllowPopupsToEscapeSandbox AllowPopupsToEscapeSandbox = new AllowPopupsToEscapeSandbox();
        /// <summary>
        /// Allows embedders to have control over whether an iframe can start a presentation session.
        /// </summary>
        public static AllowPresentation AllowPresentation = new AllowPresentation();
        /// <summary>
        /// Allows the content to be treated as being from its normal origin. If this keyword is not used, the embedded content is treated as being from a unique origin.
        /// </summary>
        public static AllowSameOrigin AllowSameOrigin = new AllowSameOrigin();
        /// <summary>
        /// Allows the embedded browsing context to run scripts (but not create pop-up windows). If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static AllowScripts AllowScripts = new AllowScripts();
        /// <summary>
        /// Allows the embedded browsing context to navigate (load) content to the top-level browsing context. If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static AllowTopNaviation AllowTopNaviation = new AllowTopNaviation();
    }
}
