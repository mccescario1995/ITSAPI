namespace ITSAPI.DTO
{
    public class UpdateIssueDto
    {
        public string? IssueDetails { get; set; } = null!;

        public string? ActionPlan { get; set; }

        public int? IssueTypeId { get; set; }

        public int? ResponsibleGroupId { get; set; }

        public string? ResponsibleEmpId { get; set; }
        public byte? Status { get; set; }
        public int? ModifiedByUserId { get; set; }



    }
}