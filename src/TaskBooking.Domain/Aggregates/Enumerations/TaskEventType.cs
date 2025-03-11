namespace TaskBooking.Domain.Aggregates.Enumerations
{
    public class TaskEventType : Enumeration
    {

        public static EventType SatyanarayanKatha = new(1, "Satyanarayan Katha");
        public static EventType GaneshPuja = new(2, "Ganesh Puja");
        public static EventType LakshmiPuja = new(3, "Lakshmi Puja");
        public static EventType SaraswatiPuja = new(4, "Saraswati Puja");
        public static EventType DurgaPuja = new(5, "Durga Puja");
        public static EventType KaliPuja = new(6, "Kali Puja");
        public static EventType HanumanPuja = new(7, "Hanuman Puja");
        public static EventType ShivratriPuja = new(8, "Shivratri Puja");
        public static EventType JanmashtamiPuja = new(9, "Janmashtami Puja");
        public static EventType RamNavamiPuja = new(10, "Ram Navami Puja");
        public static EventType NavagrahaPuja = new(11, "Navagraha Puja");
        public static EventType Rudrabhishek = new(12, "Rudrabhishek");
        public static EventType ChandiPath = new(13, "Chandi Path");
        public static EventType VastuShantiPuja = new(14, "Vastu Shanti Puja");
        public static EventType NavratriPuja = new(15, "Navratri Puja");
        public static EventType MahaMrityunjayaJaap = new(16, "Maha Mrityunjaya Jaap");
        public static EventType SundarkandPath = new(17, "Sundarkand Path");
        public static EventType KarvaChauthPuja = new(18, "Karva Chauth Puja");
        public static EventType TeejPuja = new(19, "Teej Puja");
        public static EventType ChhathPuja = new(20, "Chhath Puja");
        public static EventType BhoomiPuja = new(21, "Bhoomi Puja");
        public static EventType LakhBatti = new(22, "Lakh Batti");
        public static EventType Pasni = new(23, "Pasni");
        public static EventType NewHomePuja = new(24, "New Home Puja");
        public static EventType Birthday = new(25, "Birthday");
        public static EventType ShraddhaKarma = new(26, "Shraddha Karma");
        public static EventType VivahSanskar = new(27, "Vivah Sanskar");
        public static EventType AntimSanskar = new(28, "Antim Sanskar");
        public static EventType Annaprashan = new(29, "Annaprashan");
        public static EventType Upanayana = new(30, "Upanayana");
        public static EventType GrihaPravesh = new(31, "Griha Pravesh");
        public static EventType Other = new(32, "Other");


        public TaskEventType(int id, string name) : base(id, name)
        {
        }
    }
}
