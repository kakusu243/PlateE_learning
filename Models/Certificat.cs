namespace PlateE_learning.Models
{
    public class Certificat
    {
        public int Id { get; set; }
        public string NumeroUnique { get; set; } = string.Empty;
        public DateTime DateEmission { get; set; }
        public string NomApprenant { get; set; } = string.Empty;
        public string TitreCours { get; set; } = string.Empty;

        // 🔧 Ajout des propriétés utilisées dans CertificatDesigner.razor
        public string Signataire { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
