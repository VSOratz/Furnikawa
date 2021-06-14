using System.Web;

namespace PickingByVoice.Models
{
    public class UsuarioView
    {
        public Usuario Usuario { get; set; }

        public HttpPostedFileBase Foto { get; set; }
    }
}