namespace PlateE_learning.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Enonce { get; set; } = string.Empty;

        // Options de réponse pour le QCM
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;

        // Stocke la clé de la bonne réponse ("A", "B", "C", ou "D")
        public string ReponseCorrecte { get; set; } = "A";

        // Pondération / Points attribués à cette question spécifique
        public int Points { get; set; } = 1;

        // 🔗 Clé étrangère et relation vers Evaluation
        public int EvaluationId { get; set; }
        public Evaluation? Evaluation { get; set; }
    }
}