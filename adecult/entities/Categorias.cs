using System;
using System.Collections.Generic;

namespace adecult.entities
{
    public class Categorias
    {
        public Categorias()
        {
            InverseCatPadreNavigation = new HashSet<Categorias>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CatPadre { get; set; }

        public virtual Categorias CatPadreNavigation { get; set; }
        public virtual ICollection<Categorias> InverseCatPadreNavigation { get; set; }
    }
}
