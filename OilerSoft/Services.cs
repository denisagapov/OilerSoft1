//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OilerSoft
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdSpare { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual ClientSet ClientSet { get; set; }
        public virtual SpareSet SpareSet { get; set; }
    }
}
