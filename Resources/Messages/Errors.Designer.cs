﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources.Messages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Errors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Messages.Errors", typeof(Errors).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} already exists!.
        /// </summary>
        public static string AlreadyExists {
            get {
                return ResourceManager.GetString("AlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You should just use digits!.
        /// </summary>
        public static string Captcha {
            get {
                return ResourceManager.GetString("Captcha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current password is not correct!.
        /// </summary>
        public static string CurrentPasswordIsNotCorrect {
            get {
                return ResourceManager.GetString("CurrentPasswordIsNotCorrect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email address is not verified yet!.
        /// </summary>
        public static string EmailAddressIsNotVerified {
            get {
                return ResourceManager.GetString("EmailAddressIsNotVerified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Username or Password!.
        /// </summary>
        public static string InvalidUsernameOrPassword {
            get {
                return ResourceManager.GetString("InvalidUsernameOrPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New password can not be same as current password!.
        /// </summary>
        public static string NewPasswordCanNotBeSameAsCurrentPassword {
            get {
                return ResourceManager.GetString("NewPasswordCanNotBeSameAsCurrentPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected error!.
        /// </summary>
        public static string UnexpectedError {
            get {
                return ResourceManager.GetString("UnexpectedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your account is not active!.
        /// </summary>
        public static string UserAccountIsNotActive {
            get {
                return ResourceManager.GetString("UserAccountIsNotActive", resourceCulture);
            }
        }
    }
}
