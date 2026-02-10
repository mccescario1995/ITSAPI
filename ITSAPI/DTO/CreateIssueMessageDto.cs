namespace ITSAPI.DTO
{
    public class CreateIssueMessageDto
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string MessageDetail { get; set; } = null!;
        public byte OldStatusId { get; set; }
        public byte StatusId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}