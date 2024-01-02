// Pages/Home/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASAG_ILIK_nvOM.Pages.Home
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // Kullanýcýnýn giriþ yapmýþ olmasý durumunda sayfaya yönlendirme yapabilirsiniz
            if (User.Identity.IsAuthenticated)
            {
                // Örneðin, ilanlarý görüntüleme sayfasýna yönlendirme
                Response.Redirect("/Announcements/Index");
            }
        }
    }
}
