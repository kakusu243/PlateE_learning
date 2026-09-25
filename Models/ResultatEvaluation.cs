using PlateE_learning.Models;

public class ResultatEvaluation
{
    public int Id { get; set; }

    // Clé étrangère vers l'apprenant
    public int ApprenantId { get; set; }
    public Utilisateur? Apprenant { get; set; }

    // Clé étrangère vers l'évaluation
    public int EvaluationId { get; set; }
    public Evaluation? Evaluation { get; set; }

    // Les scores
    public int PointsObtenus { get; set; }
    public int PointsMax { get; set; }
    public double Pourcentage => PointsMax > 0 ? (double)PointsObtenus / PointsMax * 100 : 0;

    // Statut de réussite (ex: seuil fixé à 50% ou 60%)
    public bool EstReussi { get; set; }

    // Horodatage
    public DateTime DateTentative { get; set; } = DateTime.Now;
}
