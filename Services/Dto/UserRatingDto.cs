namespace ServiceLayer.Dto
{
    public class UserRatingDto
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int RatingId { get; set; }
        public string Comments { get; set; }
    }
}
