using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Business.Dtos.Abstract;

public abstract class BaseDto
{
    public int Id { get; set; }
}
