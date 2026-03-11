using Solution.Database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Database.Entities;

[Table("Hero")]
public class HeroEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    public int Intelligence { get; set; }
    [Required]
    public int Agility { get; set; }
    [Required]
    public int Strength { get; set; }
    [Required]
    public int Health { get; set; }
    [Required]
    public int Physical { get; set; }
    [Required]
    public int Magic { get; set; }
    [Required]
    public int Armor { get; set; }
    [Required]
    public int MagicDef { get; set; }
    [Required]
    public int MagicPen { get; set; }
    [Required]
    public int ArmorPen { get; set; }
    [Required]
    public HeroRole Role { get; set; }

}
