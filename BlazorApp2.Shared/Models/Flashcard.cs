using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp2.Shared.Models
{
    public partial class Flashcard
    {
        public int FlashcardId { get; set; }
        public string Label { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
