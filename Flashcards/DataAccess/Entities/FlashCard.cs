using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public partial class FlashCard
{
    public int Id { get; set; }
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public bool? WasCorrect { get; set; }
}
