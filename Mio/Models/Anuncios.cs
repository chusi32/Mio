using System;
namespace Mio.Models
{
    public class Anuncios
    {
        #region Public Properties
        public string title { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int precio { get; set; }
        public string idCategoria { get; set; }
        public string idUsuario { get; set; }
        public DateTime fecha { get; set; }
        #endregion

        #region Constructor
        public Anuncios()
        {
        }
        #endregion
    }
}
