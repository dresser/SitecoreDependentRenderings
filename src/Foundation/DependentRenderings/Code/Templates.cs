using Sitecore.Data;

namespace Sitecore.Foundation.DependentRenderings
{
    public class Templates
    {
        public struct ControllerRenderingWithScript
        {
            public static readonly ID ID = new ID("{7E057323-0940-433E-9B47-B084D4CB99C0}");
        }

        public struct ViewRenderingWithScript
        {
            public static readonly ID ID = new ID("{6BB602DC-7BDE-4AB6-8671-4C7D9D86848D}");
        }

        public struct BaseRenderingWithScript
        {
            public static readonly ID ID = new ID("{186A1259-5C04-43E3-A945-760B6F685BA9}");

            public struct Fields
            {
                public static ID RelatedRenderings = new ID("{DCF3E633-C233-4250-AF3B-926E88F9153E}");
            }
        }

        public struct Rendering
        {
            public struct Fields
            {
                public static readonly string Placeholder = "Placeholder";
            }
        }
    }
}