using System;

namespace miniBank
{
    public class transaction
    {
        public int trasactionId { get; set; }

        public string transactionTitle { get; set; }

        public DateTime transactiondate { get; set; } = DateTime.Now;

        public account account{ get; set;}
    }
}