using System;
using System.Collections.Generic;

namespace miniBank
{
    public class account
    {
        public int id { get; set; }

        public string accountName { get; set; }

        public int accountNumber { get; set; }

        public decimal? accountBalance { get; set; }

        public virtual ICollection<transaction> transaction{ get; set; }
        
            List<account> Seededaccounts = new List<account> (){
                new account{
                    accountName ="Val Ikegbunam", accountNumber = 10121525
                },
                new account{},
            }
                
            
    }
}