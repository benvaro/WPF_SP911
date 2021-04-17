namespace MVVM.Model
{

    public class CityInfo
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public AdministrativeInfo Country { get; set; }
        public AdministrativeInfo AdministrativeArea { get; set; }
    }

    public class AdministrativeInfo
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

}
