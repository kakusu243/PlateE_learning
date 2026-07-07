namespace PlateE_learning.Models
{
    public class Certificat
    {
        public int Id { get; set; }
        public string NumeroUnique { get; set; }
        public DateTime DateEmission { get; set; }
        public string NomApprenant { get; set; }
        public string TitreCours { get; set; }

        // 🔧 Ajout des propriétés utilisées dans CertificatDesigner.razor
        public string Signataire { get; set; }
        public string Description { get; set; }
    }
}
