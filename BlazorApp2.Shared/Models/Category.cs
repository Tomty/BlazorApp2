using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp2.Shared.Models
{
    public partial class Category
    {
        public Category()
        {
            Flashcard = new HashSet<Flashcard>();
        }

        public int CategoryId { get; set; }
        public string Label { get; set; }
        public string Difficulty { get; set; }

        public virtual ICollection<Flashcard> Flashcard { get; set; }
    }
}
