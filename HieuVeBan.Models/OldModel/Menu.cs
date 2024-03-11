namespace HieuVeBan.Models.OldModel
{
    public class Menu
    {
        public Menu(string MenuName, string Url, string Icon)
        {
            this.MenuName = MenuName;
            this.Url = Url;
            this.Icon = Icon;
        }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
