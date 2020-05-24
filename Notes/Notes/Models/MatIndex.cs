using SQLite;

using System;
using System.Collections.Generic;

namespace Notes.Models
{
    public class MatIndex
    {
        public class Vara
        {
            [PrimaryKey, AutoIncrement]
            public long VaruID { get; set; }
            public string Text { get; set; }
            public string Description { get; set; }
            public string Manufacturer { get; set; }
            public string ProductCode { get; set; }
            public long Amount { get; set; }
            public DateTime Date { get; set; }
            public byte[] Image { get; set; }
            public string StringBilden { get; set; }

            public static implicit operator List<object>(Vara v)
            {
                throw new NotImplementedException();
            }
        }
        public class Butik
        {
            [PrimaryKey, AutoIncrement]
            public int ButikID { get; set; }
            public string Name { get; set; }
            public string Coordinates { get; set; }
        }
        public class Saldo
        {
            public int BID { get; set; }
            public int VID { get; set; }
            public string Amount { get; set; }
            public DateTime BestBefore { get; set; }
        }
        public class Konto
        {
            [PrimaryKey, AutoIncrement]
            public int KontoID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
