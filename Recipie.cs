namespace OnlineRecipeSharing
{
    internal class Recipie
    {
        internal string cookingtime;
        internal string image;

        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string CookingTime { get; internal set; }
        public string Image { get; internal set; }
    }
}