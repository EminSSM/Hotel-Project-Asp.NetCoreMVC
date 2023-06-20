namespace HotelProject.WebUI.Dtos.FollowDto
{
    public class ResultLinkedinFollowDto
    {

        public Data data { get; set; }

        public class Data
        {
            public int followers_count { get; set; }

        }
    }
}
