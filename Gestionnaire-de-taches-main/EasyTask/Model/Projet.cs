using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTask.Model
{
    internal class Projet
    {   
        public int Id { get; set; }
        public List<Task> Tasks { get; set; }

        public int id_client { get; set; }
        public Client client { get; set; }

        public string titre { get; set; }
        public string description { get; set; }
    }
}
