﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicFacebookFeatures.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BasicFacebookFeatures.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;Events&quot;: [
        ///    {
        ///      &quot;Name&quot;: &quot;Summer Beach Party&quot;,
        ///      &quot;HostName&quot;: &quot;John Doe&quot;,
        ///	&quot;Picture&quot;: &quot;summerbeach.png&quot;,
        ///      &quot;StartTime&quot;: &quot;2024-08-30T14:00:00&quot;,
        ///      &quot;EndTime&quot;: &quot;2024-08-30T18:00:00&quot;,
        ///      &quot;Location&quot;: &quot;Tel Aviv, Israel&quot;,
        ///      &quot;Description&quot;: &quot;Join us for a fun beach party with music, games, and food! Enjoy live DJ performances, beach volleyball, and a barbecue.\n\nLine-Up:\n14:00 - Opening Music and Welcome\n15:00 - Live DJ Performance\n16:00 - Beach Volleyball Tournament\n17:00 -  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string eventData {
            get {
                return ResourceManager.GetString("eventData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;LikedPages&quot;: [
        ///    {
        ///      &quot;Page&quot;: {
        ///        &quot;Name&quot;: &quot;Tech Enthusiasts&quot;,
        ///        &quot;Category&quot;: &quot;Technology&quot;,
        ///        &quot;Posts&quot;: [
        ///          {
        ///            &quot;Message&quot;: &quot;Exploring the latest in AI technology!&quot;
        ///          },
        ///          {
        ///            &quot;Message&quot;: &quot;Join us for a webinar on blockchain technology.&quot;
        ///          },
        ///          {
        ///            &quot;Message&quot;: &quot;New gadget review: The best smartphone of 2024.&quot;
        ///          }
        ///        ]
        ///      },
        ///      &quot;Picture&quot;: &quot;https://example.com/pictures/tech_enthusia [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Liked_Pages {
            get {
                return ResourceManager.GetString("Liked_Pages", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap summerbeach {
            get {
                object obj = ResourceManager.GetObject("summerbeach", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap tech {
            get {
                object obj = ResourceManager.GetObject("tech", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
