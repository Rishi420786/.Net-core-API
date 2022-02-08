namespace ServiceLayer.Dto
{
    public class GetUserRatingDto
    {
        public int Id { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public int Rating { get; set; }
        public string RatingName { get; set; }
        public string Comments { get; set; }
    }
}
