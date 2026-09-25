namespace PlateE_learning.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public DateTime DateInscription { get; set; } = DateTime.UtcNow;
        public int Progression { get; set; } = 0; // En pourcentage (0 à 100%)
        public bool EstTermine { get; set; } = false;

        // Moyenne ou note finale de l'ensemble des évaluations du cours
        public double? NoteFinale { get; set; }

        // Date à laquelle l'étudiant a terminé et validé tout le cours
        public DateTime? DateCompletion { get; set; }

        // --- NOUVEAUTÉS POUR LE CERTIFICAT ---

        // Indique si l'enseignant ou le système a validé l'étudiant pour recevoir son certificat
        public bool EstEligibleCertificat { get; set; } = false;

        // Indique si le certificat a été officiellement généré/délivré
        public bool CertificatDelivre { get; set; } = false;

        // Date exacte de la délivrance du certificat
        public DateTime? DateDelivranceCertificat { get; set; }

        // Un code unique infalsifiable pour vérifier l'authenticité du certificat (ex: "CRMS-CERT-2026-9842")
        public string? CodeVerificationCertificat { get; set; }

        // -------------------------------------

        public int ApprenantId { get; set; }
        public Apprenant? Apprenant { get; set; }

        public int CoursId { get; set; }
        public Cours? Cours { get; set; }
    }
}