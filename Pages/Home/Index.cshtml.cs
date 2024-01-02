// Pages/Home/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASAG_ILIK_nvOM.Pages.Home
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // Kullan�c�n�n giri� yapm�� olmas� durumunda sayfaya y�nlendirme yapabilirsiniz
            if (User.Identity.IsAuthenticated)
            {
                // �rne�in, ilanlar� g�r�nt�leme sayfas�na y�nlendirme
                Response.Redirect("/Announcements/Index");
            }
        }
    }
}
