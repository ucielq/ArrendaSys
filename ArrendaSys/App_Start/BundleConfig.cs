using System.Web;
using System.Web.Optimization;

namespace ArrendaSys
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      
                      "~/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/assets/vendor/glightbox/js/glightbox.min.js",
                      "~/assets/vendor/isotope-layout/isotope.pkgd.min.js",
                      "~/assets/vendor/php-email-form/validate.js",
                      "~/assets/vendor/swiper/swiper-bundle.min.js",
                      "~/assets/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/assets/img/favicon.png",
                      "~/assets/img/apple-touch-icon.png",
                      "~/assets/vendor/animate.css/animate.min.css",
                      "~/assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/assets/vendor/bootstrap-icons/bootstrap-icons.css",
                      "~/assets/vendor/boxicons/css/boxicons.min.css",
                      "~/assets/vendor/glightbox/css/glightbox.min.css",
                      "~/assets/vendor/swiper/swiper-bundle.min.css",
                      "~/assets/css/style.css"                      
                      ));
        }
    }
}
