using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DtoLayer.PersonDto
{
    //DTO genellikle bir veri katmanından başka bir katmana veri taşımak için kullanılan basit nesnelerdir.
    //Bir katmanda elimizde var olan data diğer katmanda kullanılacak ise,
    //veriyi tasımak diğer katmanda yeniden çağrım yapmamak için anlamlı bir çözümdür.
    public class ResultPersonDto
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string TCKimlik { get; set; }
    }
}
